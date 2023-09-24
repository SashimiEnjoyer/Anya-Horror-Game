using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    private void Start()
    {
        textField.SetText($"Game Version : {Application.version}");
    }
}
