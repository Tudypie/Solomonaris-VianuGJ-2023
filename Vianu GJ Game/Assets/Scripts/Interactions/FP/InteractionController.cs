using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionController : MonoBehaviour
{   
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private LayerMask interactableLayer = new LayerMask();

    public GameObject interactImage;
    public TMP_Text interactText;

    public event Action<RaycastHit> OnHitSomething;

    public RaycastHit hitInfo;
    public bool hitSomething;

    [HideInInspector]
    public bool isHoldingItem = false;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckForInteractable();
    }

 
    void CheckForInteractable()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

        hitSomething = Physics.Raycast(ray, out hitInfo, rayDistance, interactableLayer);


        if(hitSomething)
        {           
            interactImage.SetActive(true); 
        }
        else
        {
            hitInfo = default(RaycastHit);

            interactImage.SetActive(false); 
        }

        OnHitSomething?.Invoke(hitInfo);

        Color rayColor = hitSomething ? Color.green : Color.red;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayColor);
    }
            
}