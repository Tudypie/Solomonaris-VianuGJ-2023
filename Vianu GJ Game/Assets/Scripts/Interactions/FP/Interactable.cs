using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private string interactText;
    [Space]
    [SerializeField] private bool holdInteraction = false;
    [SerializeField] private float holdTime = 0f;
    [SerializeField] private string holdText;
    [SerializeField] private AudioClip holdAudio;
    [Space]
    [SerializeField] private UnityEvent hoverEvent;
    [SerializeField] private UnityEvent stopHoverEvent;
    [SerializeField] private UnityEvent interactEvent;

    private InteractionController interactionController;

    private bool canInteract = false;
    private bool hoveredAtLeastOnce = false;

    private const int INTERACTABLE_LAYER = 6;

    private void Start()
    {
        if(interactionController == null)
            interactionController = GameObject.FindObjectOfType<InteractionController>();

        interactionController.OnHitSomething += CheckInteraction;
    }

    private void OnDestroy()
    {
        interactionController.OnHitSomething -= CheckInteraction;
    }

    private void Update()
    {   
        if(gameObject.layer != INTERACTABLE_LAYER)
            return;

        if(hoveredAtLeastOnce)
            stopHoverEvent?.Invoke();

        if(!canInteract)
            return;

        hoverEvent?.Invoke();

        hoveredAtLeastOnce = true;

        interactionController.interactText.text = interactText;

        if(!Input.GetKeyDown(interactKey))
            return;

        if(holdInteraction)
        {
            StartCoroutine(HoldInteraction());
            return;
        }
    
        interactEvent?.Invoke();
    }

    private void CheckInteraction(RaycastHit hit)
    {
        canInteract = hit.collider == GetComponent<Collider>();
    }

    public void StopInteraction(bool interactable)
    {
        if(!interactable)
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = INTERACTABLE_LAYER;
        }
    }

    public void ChangeInteractText(string text)
    {
        interactText = text;
    }

    private IEnumerator HoldInteraction()
    {
        float timer = 0f;
        AudioPlayer.Instance.PlayAudio(holdAudio);

        while(timer < holdTime)
        {   
            interactionController.interactText.text = holdText + " - " + (holdTime-timer).ToString("F1");

            if(Input.GetKeyUp(interactKey) || !canInteract)
            {   
                AudioPlayer.Instance.StopAudio();
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        if(timer >= holdTime)
            interactEvent?.Invoke();
    }

}