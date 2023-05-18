using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{      
    [SerializeField] private GameObject torchModel;


    public void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Player")
        {
            torchModel.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //torchModel.SetActive(false);
        }
    }
}
