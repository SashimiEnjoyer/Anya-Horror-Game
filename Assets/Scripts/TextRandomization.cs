using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRandomization : MonoBehaviour
{
    public List<string> text;
    private TMP_Text textMesh;


    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        Randomize();
    }

    void Update()
    {
        
    }

    public void Randomize()
    {
        int n = text.Count;
        int rng = Random.Range(0, n - 1);
        textMesh.text = text[rng];
    }
}
