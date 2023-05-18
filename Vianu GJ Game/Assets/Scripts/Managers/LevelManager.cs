using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] levelNames;
    [SerializeField] private GameObject[] levelButtons;

    private int timesPressed;

    private void Start()
    {
        for(int i = 0; i < levelNames.Length; i++)
        {
            if (PlayerPrefs.GetInt(levelNames[i].ToString()) == 1)
            {
                levelButtons[i].SetActive(true);
            }
            else
            {
                levelButtons[i].SetActive(false);
            }
        }

    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
            timesPressed++;

        if(timesPressed == 9)
        {
            for(int i = 0; i < levelNames.Length; i++)
            {   
                PlayerPrefs.SetInt(levelNames[i].ToString(), 1);
                if (PlayerPrefs.GetInt(levelNames[i].ToString()) == 1)
                {
                    levelButtons[i].SetActive(true);
                }
            }
        }
    }
}
