using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{   
    [System.Serializable]
    public struct Item
    {
        public string name;
        public int amount;
        public TMP_Text amountText;
    }

    public Item[] items = new Item[5];

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(int index, int amount)
    {
        items[index].amount += amount;
        if(items[index].amountText != null)
            items[index].amountText.text = items[index].amount.ToString();
    }

    public void RemoveItem(int index, int amount)
    {
        items[index].amount -= amount;
        if(items[index].amountText != null)
            items[index].amountText.text = items[index].amount.ToString();
    }

    public void AddOneItem(int index)
    {
        items[index].amount += 1;
        if(items[index].amountText != null)
            items[index].amountText.text = items[index].amount.ToString();
    }

}
