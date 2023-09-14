using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string sceneLoadStartAdditive;
    public string lastAdditionalSceneActive;
 
    [Header("Store Object for UI Indicator")]
    public GameObject panelItemIndicator;


    void Start()
    {
        if (sceneLoadStartAdditive != null)
        {
            SceneManager.LoadSceneAsync(sceneLoadStartAdditive, LoadSceneMode.Additive);
            lastAdditionalSceneActive = sceneLoadStartAdditive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel()
    {
        if (lastAdditionalSceneActive != null)
        {
            UnloadScene(lastAdditionalSceneActive);
        }
        SceneManager.LoadScene("Level 1a");
    }

    public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        lastAdditionalSceneActive = sceneName;
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        lastAdditionalSceneActive = null;
    }

    [ContextMenu("Unload Scene Additive")]
    public void TestUnloadScene()
    {
        SceneManager.UnloadSceneAsync(sceneLoadStartAdditive);
    }
}
