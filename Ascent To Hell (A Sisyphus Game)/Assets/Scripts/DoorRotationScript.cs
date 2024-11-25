using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorRotationScript: MonoBehaviour
{
    private List<string> thoughtText = new();             // Thought List
    private static GameObject doorRotationPoint;          // gameObject
    private bool hasPlayerThought = false;                // Has thought canvas been activated
    private int sceneIndex;                               // Scene Index

    private void Start()
    {
        doorRotationPoint = gameObject;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    #region Timed Thought Text
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only thinks for the first time
        if (!hasPlayerThought)
        {
            // Determines thinking text
            switch (sceneIndex)
            {
                case 1:
                    thoughtText.Add("Really? A locked door? Man...");
                    thoughtText.Add("Looks like a combination lock with 4 numbers...");
                    ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                    break;
                case 4:
                    thoughtText.Add("I guess this is still here. At least I know what to do.");
                    ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                    break;
                case 7:
                    thoughtText.Add("*sigh*");
                    ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                    break;
            }

            hasPlayerThought = true;
        }
    }
    #endregion

    #region Animation
    public static void OpenDoor()
    {
        doorRotationPoint.GetComponent<BoxCollider2D>().enabled = false;
        doorRotationPoint.GetComponent<Animator>().Play("Door Rotation Point");
    }
    #endregion
}
