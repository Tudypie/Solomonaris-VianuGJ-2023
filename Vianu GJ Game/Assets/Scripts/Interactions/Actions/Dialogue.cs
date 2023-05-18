using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Dialogue : MonoBehaviour
{   
    [SerializeField] private Interactable interactable;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;

    [System.Serializable]
    private struct dialogueLine
    {   
        public string name;
        public string line;
        public AudioClip audioClip;
        public bool askLine;
    }
    [SerializeField] private dialogueLine[] dialogueLines;

    [SerializeField] private float typeWriterEffectDelay = 0.04f;
    private float nextLineDelay;

    [Space]

    [SerializeField] private UnityEvent StartDialogueEvent;
    [SerializeField] private UnityEvent StopDialogueEvent;

    [SerializeField] private int dialogueIndex = 0;

    public void StartDialogue()
    {   
        dialogueUI.SetActive(true);
        nameText.text = dialogueLines[dialogueIndex].name;
        StartCoroutine(ShowText(dialogueLines[dialogueIndex].line));
        AudioPlayer.Instance.PlayAudio(dialogueLines[dialogueIndex].audioClip);
        interactable.StopInteraction(false);
        nextLineDelay = 0.1f;
        StartDialogueEvent?.Invoke();
    }

    private void Update()
    {   
        if(!dialogueUI.activeSelf)
            return;

        if(dialogueIndex > dialogueLines.Length)
            return;

            
        if(Input.GetKeyDown(KeyCode.Space))
        {
            typeWriterEffectDelay = 0.01f;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            typeWriterEffectDelay = 0.045f;
        }
            
        if(nextLineDelay > 0)
            return;

        
        if(!Input.GetMouseButtonDown(0))
            return;

        nameText.text = "";
        dialogueText.text = "";
        AudioPlayer.Instance.StopAudio();

        dialogueIndex++;
        if(dialogueIndex+1 > dialogueLines.Length)
        {   
            dialogueIndex = 0;
            EscapeDialogue();
            return;
        }

        dialogueText.text = dialogueLines[dialogueIndex].line;

        if(dialogueLines[dialogueIndex].askLine)
            return;

        StartCoroutine(ShowText(dialogueLines[dialogueIndex].line));

        nameText.text = dialogueLines[dialogueIndex].name;
        AudioPlayer.Instance.PlayAudio(dialogueLines[dialogueIndex].audioClip);


        nextLineDelay = 0.1f;
    }

    IEnumerator ShowText(string fullText)
    {   
		for(int i = 0; i < fullText.Length+1; i++)
        {   
			string currentText = fullText.Substring(0,i);
            dialogueText.text = currentText;
			yield return new WaitForSeconds(typeWriterEffectDelay);
		}

        nextLineDelay = 0;
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EscapeDialogue();
        }
    }

    private void EscapeDialogue()
    {
        dialogueUI.SetActive(false);
        interactable.StopInteraction(true);
        nameText.text = "";
        dialogueText.text = "";
        AudioPlayer.Instance.StopAudio();
        StopAllCoroutines();
        StopDialogueEvent?.Invoke();
    }

}
