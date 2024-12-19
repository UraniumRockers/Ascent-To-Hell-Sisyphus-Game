using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorRotationScript: MonoBehaviour
{
    public static bool canPlayerMove = true;              // Can Player Move

    private static GameObject doorRotationPoint;          // gameObject
    private static Animator animator;                     // Animator
    private List<string> thoughtText = new();             // Thought List
    private bool hasPlayerThought = false;                // Has thought canvas been activated
    private int sceneIndex;                               // Scene Index

    private void Start()
    {
        // Defining variables
        doorRotationPoint = gameObject;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    #region Timed Thought Text
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
        }
        
        //else
        //{
        //    thoughtText.Clear();
        //    thoughtText.Add("I need a 3 digit password.");
        //    ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
        //}

    }
    #endregion

    #region Animation
    public static void OpenDoor()
    {
        animator = doorRotationPoint.GetComponent<Animator>();
        doorRotationPoint.GetComponent<BoxCollider2D>().enabled = false;
        animator.enabled = true;
        animator.Play("Door Rotation Point");
        canPlayerMove = false;
        //print("Player can't move");
    }
    #endregion

    #region Animation Movement
    public void EndAnimation()
    {
        //print("Animation is over");
        DoorRotationScript.canPlayerMove = true;
        //print("Player can move");
        thoughtText.Clear();
        if (sceneIndex == 1)
        {
            thoughtText.Add("There we go.");
            ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
        }
    }
    #endregion
}
