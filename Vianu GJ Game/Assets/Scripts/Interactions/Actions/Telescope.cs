using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Telescope : MonoBehaviour
{   
    
    [SerializeField] private UnityEvent escapeEvent;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            escapeEvent?.Invoke();
        }
            

    }
}
