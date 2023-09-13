using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Dialogue
{
    public string name;
    public float timer;
    [TextArea(5,15)]
    public string lines;
    public UnityEvent OnDialogueEvent;
}

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public bool canNotMove;
    public Dialogue[] dialogueLines;
    public UnityEvent OnFinishDialogue;
    
    private int counter;
    private bool isStarting;
    private TMP_Text dialogueText;
    private float timer;

    public void StartDialogue() 
    {
        if (canNotMove)
            InGameStatus.status = EStatus.stop;

        dialogueUI.SetActive(true);
        dialogueText = dialogueUI.GetComponentInChildren<TMP_Text>();
        NextDialogue();
        isStarting = true;
    }

    public void NextDialogue()
    {
        Debug.Log("Current Dialogue " + counter);
        timer = 0f;
        dialogueText.SetText(dialogueLines[counter].lines);
        dialogueLines[counter].OnDialogueEvent?.Invoke();
    }

    private void Update()
    {
        if (!isStarting)
            return;

        if(counter == dialogueLines.Length - 1)
        {
            Debug.Log("Done Dialogue");
            timer = 0f;
            isStarting = false;
            OnFinishDialogue?.Invoke();
            InGameStatus.status = EStatus.play;
            dialogueUI.SetActive(false);
            gameObject.SetActive(false);
            return;
        }

        if(timer > dialogueLines[counter].timer)
        {
            counter++;
            NextDialogue();
        }

        timer += Time.deltaTime;

    }


}
