using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hold : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    
    private InteractionController interactionController;
    private Interactable interactable;
    private Rigidbody rb;

    private bool isHoldingThisItem = false;
    private bool lerpPos = false;

    private void Start()
    {   
        if(interactionController == null)
            interactionController = GameObject.FindObjectOfType<InteractionController>();

        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        interactable.enabled = interactionController.isHoldingItem? false : true;

        if(isHoldingThisItem && Input.GetKeyDown(KeyCode.G))
        {
            transform.SetParent(null);

            interactionController.isHoldingItem = false;

            interactable.StopInteraction(true);

            isHoldingThisItem = false;

            rb.isKinematic = false;
        }
            

        if(!lerpPos)
            return;

        transform.position = Vector3.Lerp(transform.position, itemHolder.position, 0.05f);

        if(Vector3.Distance(transform.position, itemHolder.position) < 0.1f)
            lerpPos = false;
    }


    public void Interact()
    {
        if(interactionController.isHoldingItem)
            return;

        transform.SetParent(itemHolder);

        rb.isKinematic = true;

        lerpPos = true;
        
        interactionController.isHoldingItem = true;

        interactable.StopInteraction(false);

        isHoldingThisItem = true;
    }

    public void Destroy()
    {
        interactionController.isHoldingItem = true;
        Destroy(gameObject);
    }
}
