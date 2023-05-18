using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveSystem : MonoBehaviour
{
    [SerializeField] private GameObject objectiveUI;
    [SerializeField] private TMP_Text objectiveText;

    [SerializeField] private Animator objectiveAnimator;

    public void UpdateObjective(string objective)
    {
        objectiveText.text = "";
        objectiveAnimator.Play("ShowObjective");
        StartCoroutine(ShowText(objective));
    }

    public void HideObjective()
    {
        objectiveAnimator.Play("HideObjective");
    }   

    IEnumerator ShowText(string fullText)
    {   
        yield return new WaitForSeconds(1.5f);
		for(int i = 0; i < fullText.Length+1; i++)
        {
			string currentText = fullText.Substring(0,i);
            objectiveText.text = currentText;
			yield return new WaitForSeconds(0.04f);
		}
	}
}
