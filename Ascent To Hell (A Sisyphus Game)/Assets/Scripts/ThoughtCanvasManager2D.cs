using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtCanvasManager2D : MonoBehaviour
{
    private static GameObject thoughtBar;
    private static TMP_Text thoughtText;
    void Start()
    {
        // Defining variables and deactivating variables
        thoughtBar = GameObject.Find("Thought Bar");
        thoughtText = thoughtBar.GetComponentInChildren<TMP_Text>();
        thoughtBar.SetActive(false);
    }

    #region Test
    // KEY INPUTS FOR TESTING 
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            print("This should generate the text");
            ThoughtCanvasManager2D.SetThoughtBarText("This is a test");
        }
    }
    */
    #endregion

    #region Timed Text Code

    // Coroutine that creates timed text
    private IEnumerator GenerateTimedText(string text, float time)
    {
        thoughtText.text = "You: ";
        foreach (char character in text)
        {
            thoughtText.text += character;
            yield return new WaitForSeconds(time);
        }
        foreach (char character in " (Press 'E' to exit)")
        {
            thoughtText.text += character;
            yield return new WaitForSeconds(time);
        }
    }

    // Activate Thought Bar & Call Coroutine
    public static void SetThoughtBarText(string text)
    {
        ThoughtCanvasManager2D.thoughtBar.SetActive(true);
        ThoughtCanvasManager2D thoughtCanvas = GameObject.FindObjectOfType<ThoughtCanvasManager2D>();
        if (thoughtCanvas != null)
        {
            thoughtCanvas.StartCoroutine(thoughtCanvas.GenerateTimedText(text, 0.05f));
        }
    }

    #endregion
}
