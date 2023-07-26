using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueGeneral : MonoBehaviour
{
    [Header("Dialogue Details")]
    public List<string> dialogueNode = new List<string>();

    public int dialogueCount;
    public int currentDialogue;
    public string currentString;

    public float timer;
    public bool isInputing;
    private TutorialDialogue dialogueScript;

    void Start()
    {
        dialogueCount = dialogueNode.Count - 1;
        currentDialogue = 0;
        isInputing = false;
    }

    public void Execute(TutorialDialogue tutorialDialogue)
    {
        dialogueScript = tutorialDialogue;
        tutorialDialogue.inputText(currentString);
        isInputing = true;
        
    }

    void Update()
    {
        currentString = dialogueNode[currentDialogue];

        if (isInputing == true)
        {
            timer = dialogueScript.timingInScreen;
            //dialogueScript.midChange(currentString);

            if (timer < 0.1)
            {
                
                dialogueScript.inputText(dialogueNode[currentDialogue+1]);
                currentDialogue += 1;
                

                if (currentDialogue == dialogueCount)
                {
                    endDialogue();
                }
            }

                
        }
    }

    public void endDialogue()
    {
        dialogueScript.midChange(currentString);
        isInputing = false;
    }
    
}