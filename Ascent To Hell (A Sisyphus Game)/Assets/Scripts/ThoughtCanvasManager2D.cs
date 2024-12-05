using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ThoughtCanvasManager2D : MonoBehaviour
{
    public static bool canPlayerMove = true;                     // Can player move

    [SerializeField] private float textSpeed = 0.035f;           // Text generation speed
    private static GameObject thoughtBar;                        // The parent for all of the UI stuff
    private static TMP_Text thoughtText;                         // The text
    private static bool isEPressed = false;                      // Detects if 'E' is pressed

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
            // print("E is pressed");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = false;
            // print("E is no longer pressed");
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
    private IEnumerator GenerateTimedText(List<string> text)
    {
        canPlayerMove = false; // Player can no longer move

        yield return new WaitForSeconds(0.1f); // Small initial wait

        foreach (string str in text)
        {
            thoughtText.text = "You: ";
            foreach (char character in str)
            {
                thoughtText.text += character;
                yield return new WaitForSeconds(textSpeed);
            }
            foreach (char character in " (Press 'E' to continue)")
            {
                thoughtText.text += character;
                yield return new WaitForSeconds(textSpeed);
            }

            // Sets isEPressed to false and won't continue until E is pressed again
            ThoughtCanvasManager2D.isEPressed = false;
            yield return new WaitUntil(() => isEPressed);
        }
        // Resets text & deactivates thought bar
        ThoughtCanvasManager2D.thoughtBar.SetActive(false);
        ThoughtCanvasManager2D.thoughtText.text = "You: ";
        canPlayerMove = true; // Player can move again
    }

    // Activate Thought Bar & Call Coroutine
    public static void SetThoughtBarText(List<string> text)
    {
        ThoughtCanvasManager2D thoughtCanvas = GameObject.FindObjectOfType<ThoughtCanvasManager2D>();
        //thoughtBar.SetActive(true);
        if (thoughtCanvas != null)
        {
            ThoughtCanvasManager2D.thoughtBar.SetActive(true);
            thoughtCanvas.StartCoroutine(thoughtCanvas.GenerateTimedText(text));
        }
    }

    #endregion
}
