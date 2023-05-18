using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTorch : MonoBehaviour
{
    [SerializeField] private GameObject torch;
    [SerializeField] private GameObject blueprintTorch;

    private GameObject blueprintInstance;

    private void Update()
    {
        if(Inventory.Instance.items[0].amount <= 0)
        {   
            gameObject.layer = 0;
        }
    }

    public void OnHover()
    {
        if(Inventory.Instance.items[0].amount <= 0)
            return;

        if(blueprintInstance == null)
            blueprintInstance = Instantiate(blueprintTorch, transform.position, transform.rotation);
        else
            blueprintInstance.SetActive(true);
    }

    public void StopHover()
    {
        if(blueprintInstance == null)
            return;

        blueprintInstance.SetActive(false);
    }

    public void SpawnTorch()
    {   
        if(Inventory.Instance.items[0].amount <= 0)
            return;
        
        Inventory.Instance.RemoveItem(0, 1);

        blueprintInstance.SetActive(false);
        Instantiate(torch, transform.position, transform.rotation);
        gameObject.layer = 0;
        enabled = false;
    }
}
