using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockPuzzleDigit : MonoBehaviour
{
    public ItemInteractAppear itemInteractAppear;

    [Header("Assign Cylinders")]
    public Transform cylinder1;
    public Transform cylinder2;
    public Transform cylinder3;
    
    private int code1 = 1;
    private int code2 = 2;
    private int code3 = 3;
    private int digitCount;

    [Header("Code Check")]
    public float digit1;
    public float digit2;
    public float digit3;

    void Start()
    {
        itemInteractAppear = gameObject.transform.parent.gameObject.GetComponent<ItemInteractAppear>();
        digitCount = Mathf.FloorToInt(Mathf.Log10(itemInteractAppear.passcode)) + 1;

        if (digitCount == 3)
        {
            code1 = digitExtract(1);
            code2 = digitExtract(2);
            code3 = digitExtract(3);
        }
        else Debug.Log("Assigned passcode with more than 3 digits, passcode defaults to 123");
    }

    void Update()
    {
        digit1 = angleToCode(cylinder1.localEulerAngles.z);
        digit2 = angleToCode(cylinder2.localEulerAngles.z);
        digit3 = angleToCode(cylinder3.localEulerAngles.z);

        if (digit1 == code1 && digit2 == code2 && digit3 == code3)
        {
            itemInteractAppear.onFinishEvent.Invoke();
            itemInteractAppear.puzzleEnd();

        }
    }

    float angleToCode(float valueA)
    {
        float result;

        if (Mathf.Floor((360 - valueA) / 36) == 10)
            result = 0;
        else result = Mathf.Round((360 - valueA) / 36);

        return result;
    }

    int digitExtract(int digit)
    {
        int result1;
        char[] chars;
        string string1;

        string1 = itemInteractAppear.passcode.ToString();
        chars = string1.ToCharArray();
        result1 = int.Parse(chars[digit - 1].ToString());

        return result1;
    }
}
