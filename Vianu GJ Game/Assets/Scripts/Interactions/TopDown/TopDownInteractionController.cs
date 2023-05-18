using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownInteractionController : MonoBehaviour
{
    [SerializeField] public GameObject interactImage;

    [HideInInspector] public int INTERACTABLE_LAYER = 6;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == INTERACTABLE_LAYER)
        {
            interactImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == INTERACTABLE_LAYER)
        {
            interactImage.SetActive(false);
        }
    }
}
