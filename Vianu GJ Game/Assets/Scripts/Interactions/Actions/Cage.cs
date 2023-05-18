using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cage : MonoBehaviour
{
    [SerializeField] private int currentHedgehog = 0;
    [SerializeField] private int totalHedgehogs = 3;
    [Space]
    [SerializeField] private GameObject[] hedgehogs;
    [SerializeField] private GameObject itemHolder;
    [Space]
    [SerializeField] private UnityEvent CatchedAllEvent;
    [SerializeField] private UnityEvent FreeHedgehogsEvent;

    private bool canFreeHedgehogs = false;

    private InteractionController interactionController;

    private void Start()
    {
        if(interactionController == null)
            interactionController = GameObject.FindObjectOfType<InteractionController>();
    }


    public void Interact()
    {   
        if(canFreeHedgehogs)
        {
            FreeHedgehogs();
            return;
        }

        gameObject.layer = 0;
        interactionController.isHoldingItem = false;

        StartCoroutine(ActivateHedgehogModelWithDelay(currentHedgehog));
        currentHedgehog++;
        if(currentHedgehog >= totalHedgehogs)
            CatchedAllEvent?.Invoke();

    }

    private IEnumerator ActivateHedgehogModelWithDelay(int index)
    {
        yield return new WaitForSeconds(2f);
        hedgehogs[index].SetActive(true);
        Destroy(itemHolder.transform.GetChild(0).gameObject);
    }

    public void CanFreeHedgehogs()
    {
        canFreeHedgehogs = true;
    }

    public void FreeHedgehogs()
    {   
        Invoke("FreeHedgehogsWithDelay", 2.5f);
    }

    public void FreeHedgehogsWithDelay()
    {
        foreach(GameObject hedgehog in hedgehogs)
            hedgehog.SetActive(false);

        FreeHedgehogsEvent?.Invoke();

        gameObject.layer = 0;
    }

}
