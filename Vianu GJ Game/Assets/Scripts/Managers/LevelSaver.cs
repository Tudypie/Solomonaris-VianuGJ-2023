using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaver : MonoBehaviour
{
    [SerializeField] private string levelName;

    private void Start()
    {
        PlayerPrefs.SetInt(levelName, 1);
    }
}
