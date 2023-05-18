using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitles : MonoBehaviour
{   
    [SerializeField] private TMP_Text subtitleName;
    [SerializeField] private TMP_Text subtitleText;
    [Space]
    [SerializeField] private bool ongoingDialogue;

    [System.Serializable]
    struct Subtitle
    {   
        public string name;
        public string text;
        public float time;
    }
    [Space]
    [SerializeField] private Subtitle[] subtitles;



    private void Start()
    {
        subtitleText.text = "";
    }

    private void Update()
    {
        if(!ongoingDialogue)
        {
            subtitleText.text = "";
            subtitleName.text = "";
        }
    }

    public void StartDialogue()
    {
        ongoingDialogue = true;
        StartCoroutine(Dialogue());
    }

    public void StopDialogue()
    {
        ongoingDialogue = false;
        StopAllCoroutines();

        subtitleText.text = "";
        subtitleName.text = "";
    }

    IEnumerator Dialogue()
    {
        while(ongoingDialogue)
        {
            for(int i = 0; i < subtitles.Length; i++)
            {   
                subtitleName.text = subtitles[i].name;
                subtitleText.text = subtitles[i].text;
                yield return new WaitForSeconds(subtitles[i].time);
            }

            ongoingDialogue = false;
        }
    }

}
