using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TriggerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactEvent;

    [SerializeField] private string interactText;

    private TopDownInteractionController interactionController;

    private bool canInteract = false;

    private int INTERACTABLE_LAYER = 6;

     private void Start()
    {
        if(interactionController == null)
            interactionController = GameObject.FindObjectOfType<TopDownInteractionController>();

        INTERACTABLE_LAYER = interactionController.INTERACTABLE_LAYER;
    }


    private void Update()
    {   
        if(gameObject.layer != INTERACTABLE_LAYER)
            return;
            
        if(!canInteract)
            return;

        interactionController.interactImage.GetComponent<TMP_Text>().text = interactText;

        if(!Input.GetKeyDown(interactKey))
            return;
    
        interactEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactionController.interactImage.GetComponent<TMP_Text>().text = interactText;
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactionController.interactImage.GetComponent<TMP_Text>().text = "";
            canInteract = false;
        }
    }

    public void StopInteraction(bool interactable)
    {
        if(!interactable)
        {
            gameObject.layer = 0;
            interactionController.interactImage.SetActive(false);
        }
        else
        {
            gameObject.layer = INTERACTABLE_LAYER;
            interactionController.interactImage.SetActive(true);
        }
    }
}
