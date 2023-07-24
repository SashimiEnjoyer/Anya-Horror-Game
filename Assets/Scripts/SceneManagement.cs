using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string sceneLoadStartAdditive;

    void Start()
    {
        if (sceneLoadStartAdditive != null)
            SceneManager.LoadScene(sceneLoadStartAdditive, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
