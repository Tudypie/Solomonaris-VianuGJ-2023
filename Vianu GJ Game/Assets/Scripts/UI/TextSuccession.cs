using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextSuccession : MonoBehaviour
{   
    [SerializeField] private float typeWriterEffectSpeed;

    [System.Serializable]
    struct TextData
    {
        public string text;
        public AudioClip clip;
        public UnityEvent Event;
    }
    
    [SerializeField] private TextData[] introTexts;
    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private TMP_Text displayedText;
    [SerializeField] private GameObject clickText;

    private string currentText;
    private int index = 0;
    private bool textFinished = false;

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        currentText = "";
        AudioPlayer.Instance.PlayAudio(introTexts[index].clip);
        for (int i=0; i <= introTexts[index].text.Length; i++) {
            displayedText.text = currentText;
            currentText = introTexts[index].text.Substring(0, i);
            yield return new WaitForSeconds(typeWriterEffectSpeed);
        }
        textFinished = true;
        clickText.SetActive(true);
       
    }

    void Update()
    {   
        if(index%2==0)
            backgrounds[index/2].SetActive(true);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            typeWriterEffectSpeed = 0.01f;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            typeWriterEffectSpeed = 0.045f;
        }

        if(!textFinished)
            return;

        if (!Input.GetMouseButtonDown(0))
            return;

        index++;
        clickText.SetActive(false);
        introTexts[index].Event?.Invoke();
        textFinished = false;
        AudioPlayer.Instance.StopAudio();

        StartCoroutine(ShowText());

        
    }
}
