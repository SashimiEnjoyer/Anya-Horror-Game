using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockPuzzleDigit : MonoBehaviour
{
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
        
    }

    void Update()
    {
        digitCount = Mathf.FloorToInt(Mathf.Log10(GetComponent<PuzzleController>().universalValue)) + 1;

        if (digitCount == 3)
        {
            code1 = digitExtract(1);
            code2 = digitExtract(2);
            code3 = digitExtract(3);
        }
        else Debug.Log("Assigned passcode with more than 3 digits, passcode defaults to 123");

        digit1 = angleToCode(cylinder1.localEulerAngles.z);
        digit2 = angleToCode(cylinder2.localEulerAngles.z);
        digit3 = angleToCode(cylinder3.localEulerAngles.z);

        if (digit1 == code1 && digit2 == code2 && digit3 == code3)
        {
            GetComponent<PuzzleController>().onFinish.Invoke();
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

        string1 = GetComponent<PuzzleController>().universalValue.ToString();
        chars = string1.ToCharArray();
        result1 = int.Parse(chars[digit - 1].ToString());

        return result1;
    }
}
