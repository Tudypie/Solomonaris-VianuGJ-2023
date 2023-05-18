using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private UnityEvent pauseEvent;
    [SerializeField] private UnityEvent resumeEvent;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private bool isPaused = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {   
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
            if(isPaused)
            {
                
                pauseEvent?.Invoke();
            }
            else
            {
                resumeEvent?.Invoke();
            }
                
        }

        if(!isPaused)
            return;
            
        if(Input.GetKeyDown(KeyCode.R))
        {   
            Time.timeScale = 1f;
            sceneLoader.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1f;
            sceneLoader.LoadScene(0);
        }
    }
}
