using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using Meta.XR.TrackedKeyboardSample;
using System.Diagnostics;


public class TypingTask : MonoBehaviour
{  
    
    public TMP_InputField inputField; // Where user types
    public TextMeshProUGUI highlightedText; // Displays correct/incorrect colors
    public GameObject keyboardObj;
    public WriteDataToFile writeDataToFile;
    public Toggle switchHighlightBtn;


    private bool highlightOn = true;
    private bool wasActivatedOnce = false;

    private int errorCounter = 0;
    private int finalErrorCount = 0;
    private double totalWPM = 0.0;

    private Stopwatch stopwatch;
    private TimeSpan testTime;

    private int totalNumCharacters;
    private string targetText = "my favorite place to visit the quick brown fox jumped" +
        "\nthe dog will bite you there will be some fog tonight" +
        "\nthese cookies are so amazing you spilled coffee on the carpet" +
        "\nget rid of that immediately";


    private void Start()
    {
        stopwatch = new Stopwatch();
        totalNumCharacters = targetText.Length;
        inputField.onValueChanged.AddListener(UpdateTypingFeedback);

    }

    void UpdateTypingFeedback(string userInput)
    {
        highlightedText.text = GenerateColoredText(userInput);
    }

  

    string GenerateColoredText(string userInput)
    {
        string result = "";

        for (int i = 0; i < targetText.Length; i++)
        {
            // If i is within the userInput
            if (i < userInput.Length)
            {
                // If this is the first input start the stopwatch
                if (userInput.Length == 1 && !stopwatch.IsRunning)
                {
                    stopwatch.Start();
                }
                // If highlight is turned on, highlight the next key
                if (highlightOn && i != targetText.Length - 1)
                {
                    KeyboardHighlight(targetText[i + 1]);
                }
                // If the letter typed was correct
                if (userInput[i] == targetText[i])
                {
                    result += $"<color=green>{targetText[i]}</color>"; // Colors correct letters green
                }
                // If the letter typed is incorrect
                else
                {
                    // Increment the error counter (for the most recently typed word)
                    if(i == userInput.Length - 1)
                    {
                        errorCounter++;
                    }

                    finalErrorCount++;

                    result += $"<mark=#FF000080>{targetText[i]}</mark>"; // Incorrect letter marked with red highlight
                    //UnityEngine.Debug.Log("Letter marked red. Final Counter: " + finalErrorCount + " Error Count: " + errorCounter);
                }
            }
            // If i is only within the target text
            else 
            {
                result += $"<color=white>{targetText[i]}</color>"; // Unfinished letters in grey
            }
        }
        // If the user has finished typing
        if (userInput.Length == targetText.Length)
        {
            UnityEngine.Debug.Log("Done Typing Final Error: " + finalErrorCount + " Error Count: " + errorCounter);
            DoneTyping();

            if (!wasActivatedOnce)
            {
                highlightOn = !highlightOn;
                wasActivatedOnce = true;
            }
            // Activate the first letter if needed
            if (highlightOn)
            {
                KeyboardHighlight(targetText[0]);
            }
            result = $"<color=white>{targetText}</color>";

            inputField.text = "";
        }
        else
        {
            finalErrorCount = 0;
        }
        return result;
    }
    public void TurnHighlightOff()
    {
        highlightOn = false;
        switchHighlightBtn.interactable = false;
    }

    private void DoneTyping()
    {
        // Stop the stopwatch
        stopwatch.Stop();
        testTime = stopwatch.Elapsed;
        stopwatch.Reset();

        // Calculate WPM
        totalWPM = calculateWPM(testTime);

        // Turn off the last highlighted keyboard key
        keyboardObj.GetComponent<KeyboardHighlight>().TurnOffActive();

        // Pass the data to the IO class
        double timeElapsedMinutes = testTime.TotalSeconds;
        writeDataToFile.GetData(errorCounter, finalErrorCount, timeElapsedMinutes, totalWPM, highlightOn);
        // Reset data variables for next trial run
        ResetVariables();
        
    }
    private void ResetVariables()
    {
        // Reset data variables and text window
        totalWPM = 0.0;
        errorCounter = 0;
        finalErrorCount = 0;
    }
   
    private double calculateWPM(TimeSpan timeTaken)
    {
        return ((totalNumCharacters / 5.0) / timeTaken.TotalMinutes);
    }

    private void KeyboardHighlight(char letterToHighlight)
    { 
        if (keyboardObj != null)
        {
            keyboardObj.GetComponent<KeyboardHighlight>().HighlightKey(letterToHighlight);
        }
    }

}
