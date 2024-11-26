using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorRotationScript: MonoBehaviour
{
    public static bool canPlayerMove = true;              // Can Player Move

    private static bool didAnimationStart = false;        // Has the animation started yet
    private static GameObject doorRotationPoint;          // gameObject
    private List<string> thoughtText = new();             // Thought List
    private bool hasPlayerThought = false;                // Has thought canvas been activated
    private int sceneIndex;                               // Scene Index

    private void Start()
    {
        doorRotationPoint = gameObject;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        didAnimationStart = false;
    }

    private void Update()
    {
        if (didAnimationStart)
        {
            print("Animation is running");
            if (doorRotationPoint.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime == 1)
            {
                print("Animation is over");
                canPlayerMove = true;
            }
        }

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
                    thoughtText.Add("Looks like a combination lock with 3 numbers...");
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
            ObjectiveManager2DAndBossfight.Change2DObjectiveText("Find a 3-digit combination.");
            hasPlayerThought = true;
        }
        else
        {
            thoughtText.Clear();
            thoughtText.Add("I need a 3 digit password.");
            ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
            thoughtText.Clear();
        }

    }
    #endregion

    #region Animation
    public static void OpenDoor()
    {
        doorRotationPoint.GetComponent<BoxCollider2D>().enabled = false;
        doorRotationPoint.GetComponent<Animator>().Play("Door Rotation Point");  // Need to make sure that this works
        DoorRotationScript.didAnimationStart = true;                             // Still don't know if this works
        canPlayerMove = false;
    }
    #endregion
}
