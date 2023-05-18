using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;

    private void Start()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        objectsToSpawn[randomIndex].SetActive(true);
    }
}
