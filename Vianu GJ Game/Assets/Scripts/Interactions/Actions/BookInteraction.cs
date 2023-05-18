using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class BookInteraction : MonoBehaviour
{
    
    [SerializeField] private GameObject bookUI;
    [SerializeField] private TMP_Text pageNumber;
    [SerializeField] private GameObject[] bookPages;

    private int totalPages;
    [SerializeField] private int currentPage = 1;

    [SerializeField] private AudioClip pageTurnSound;

    [SerializeField] private UnityEvent escapeEvent;

    private void Start()
    {
        totalPages = bookPages.Length;
    }

    private void Update()
    {   
        if(!bookUI.activeSelf)
            return;

        bookPages[currentPage-1].SetActive(true);
        pageNumber.text = "Page " + currentPage + "/" + totalPages;

        if(Input.GetKeyDown(KeyCode.Q))
            CloseBook();

        if(!Input.GetMouseButtonDown(0))
            return;

        bookPages[currentPage-1].SetActive(false);
        currentPage++;
        AudioPlayer.Instance.PlayAudio(pageTurnSound);
        if(currentPage > totalPages)
            CloseBook();

    }

    private void CloseBook()
    {
        escapeEvent?.Invoke();
        bookUI.SetActive(false);
        currentPage = 1;
        foreach(GameObject page in bookPages)
        {
            page.SetActive(false);
        }
    }
}
