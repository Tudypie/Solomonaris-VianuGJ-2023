using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tips : MonoBehaviour
{
    [SerializeField] private TMP_Text tipText;

    public void TriggerTip(string tip)
    {
        tipText.text = "";
        StartCoroutine(ShowText(tip));
        StartCoroutine(HideTip());
    }

    IEnumerator ShowText(string fullText)
    {
		for(int i = 0; i < fullText.Length+1; i++)
        {
			string currentText = fullText.Substring(0,i);
			tipText.text = currentText;
			yield return new WaitForSeconds(0.04f);
		}
	}

    IEnumerator HideTip(float waitTime = 6f)
    {
        yield return new WaitForSeconds(waitTime);
        tipText.text = "";
    }

}
