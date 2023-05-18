using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    public bool isLoadingScene;
    public static int sceneToLoad;
    
    private void Start()
    {   
        if(isLoadingScene)
            StartCoroutine(LoadAsyncScene());
    }

    private IEnumerator LoadAsyncScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void LoadScene(int index)
    {
        sceneToLoad = index;
        SceneManager.LoadScene("Loading");
    }   
}
