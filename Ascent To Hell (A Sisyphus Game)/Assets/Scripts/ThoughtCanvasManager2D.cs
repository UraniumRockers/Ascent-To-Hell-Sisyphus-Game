using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ThoughtCanvasManager2D : MonoBehaviour
{
    public static bool shouldPlayerMove = true;

    private static GameObject thoughtBar;
    private static TMP_Text thoughtText;
    private static bool isEPressed = false;
    void Start()
    {
        // Defining variables and deactivating variables
        thoughtBar = GameObject.Find("Thought Bar");
        thoughtText = thoughtBar.GetComponentInChildren<TMP_Text>();
        thoughtBar.SetActive(false);
        isEPressed = false;
    }

    #region Key Inputs
    private void Update()
    {
        // See if 'E' is pressed
        if (Input.GetKey(KeyCode.E))
        {
            isEPressed = true;
            print("E is pressed");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = false;
            print("E is no longer pressed");
        }

        // FOR TESTING
        /*
         * if (Input.GetKeyDown(KeyCode.T))
        {
            print("This should generate the text");
            ThoughtCanvasManager2D.SetThoughtBarText("This is a test");
        }
        */
    }
    
    #endregion

    #region Timed Text Code

    // Coroutine that creates timed text
    private IEnumerator GenerateTimedText(string[] text, float time, bool wait)
    {
        shouldPlayerMove = false; // Player can no longer move

        if (wait) { yield return new WaitForSeconds(0.15f); } // Pause for a little bit for "dramatic effect"

        thoughtText.text = "You: ";
        foreach (string str in text)
        {
            foreach (char character in str)
            {
                thoughtText.text += character;
                yield return new WaitForSeconds(time);
            }
            foreach (char character in " (Press 'E' to continue)")
            {
                thoughtText.text += character;
                yield return new WaitForSeconds(time);
            }

            // Sets isEPressed to false and won't continue until E is pressed again
            ThoughtCanvasManager2D.isEPressed = false;
            yield return new WaitUntil(() => isEPressed);
        }
        // Resets text & deactivates thought bar
        ThoughtCanvasManager2D.thoughtBar.SetActive(false);
        ThoughtCanvasManager2D.thoughtText.text = "You: ";
        shouldPlayerMove = true; // Player can move again
    }

    // Activate Thought Bar & Call Coroutine
    public static void SetThoughtBarText(string text, bool wait)
    {
        ThoughtCanvasManager2D.thoughtBar.SetActive(true);
        ThoughtCanvasManager2D thoughtCanvas = GameObject.FindObjectOfType<ThoughtCanvasManager2D>();
        if (thoughtCanvas != null)
        {
            thoughtCanvas.StartCoroutine(thoughtCanvas.GenerateTimedText(text, 0.05f, wait));
        }
    }

    #endregion
}
