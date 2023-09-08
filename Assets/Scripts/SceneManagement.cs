using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string sceneLoadStartAdditive;

    [Header("Store Object for UI Indicator")]
    public GameObject panelItemIndicator;


    void Start()
    {
        if (sceneLoadStartAdditive != null)
            SceneManager.LoadSceneAsync(sceneLoadStartAdditive, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

   
    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    [ContextMenu("Unload Scene Additive")]
    public void TestUnloadScene()
    {
        SceneManager.UnloadSceneAsync(sceneLoadStartAdditive);
    }
}
