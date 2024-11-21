using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Tablet : MonoBehaviour
{
    public static bool shouldPlayerMove = true;                  // Stops player movement if the tip screen is out

    private GameObject tabletCanvas;                             // Canvas that shows tablet when interacted
    private GameObject redCloudBottom;                           // Bottom cloud (sprite & collider)
    private TMP_Text tabletText;                                 // Tablet tip text
    private bool keyDown = false;                                // Has 'E' been pressed
    private bool hasPlayerThought = false;                       // Has player already done timed text
    private List<string> thoughtBarText = new List<string>();    // List of stuff to say in timed text
    

    private void Start()
    {
        #region Defining Variables
        // Defining the variables
        tabletCanvas = GameObject.Find("Tablet Canvas");
        tabletText = tabletCanvas.GetComponentsInChildren<TMP_Text>()[0];
        tabletCanvas.SetActive(false);
        redCloudBottom = GameObject.Find("Red Cloud (Bottom)");
        hasPlayerThought = false;
        #endregion
        #region Setting Tablet Text
        // Deciding what the tablet to say based on the scene
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                tabletText.text = "This is your new life. Explore while you still have the chance. When you are ready, venture upwards. The path will reveal itself, and the pressure plate to summon your punishment will be visible.";
                break;
            case 4:
                tabletText.text = "That was just the beginning. Reaching the top will be impossible. You already know that. But you will go higher. Continue exploring, and then resummon your punishment.";
                break;
            case 7:
                tabletText.text = "Welcome back. You know the drill. Explore. When you're ready, face your punishment. This one will be harder. Prepare yourself. You will need a strong mind to have enough strength.";
                break;
            default:
                break;
        }
        #endregion
        #region Disabling Cloud Sprites
        redCloudBottom.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Red Cloud (Left)").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Red Cloud (Right)").GetComponent<SpriteRenderer>().enabled = false;
        #endregion
    }

    #region Check For Button Press
    private void Update()
    {
        // Checks every frame to see if E is down or not
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyDown = true;
            //print("Key was pressed");
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            keyDown = false;
        }

        // Checks every frame to see if the tablet canvas is visible to stop player movement
        shouldPlayerMove = !tabletCanvas.activeSelf;
    }
    #endregion

    #region Collision Detection & Tablet Text/Cloud Collider
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && keyDown)
        {
            // Enables/disables canvas and removes disables box collider, allowing the player to go down
            tabletCanvas.SetActive(!tabletCanvas.activeSelf);
            keyDown = false;
            redCloudBottom.GetComponents<BoxCollider2D>()[0].enabled = false;
            redCloudBottom.GetComponents<BoxCollider2D>()[1].enabled = true;
            redCloudBottom.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    #endregion

    #region Timed Text
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!tabletCanvas.activeSelf && !hasPlayerThought)
            {
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 1:
                        thoughtBarText.Add("...Punishment? Did I do something wrong?");
                        thoughtBarText.Add("What am I talking about. This is obviously a dream.");
                        thoughtBarText.Add("Might as well go check some stuff out.");
                        thoughtBarText.Add("That cloud over there looks kinda weird. That red's really strong...");
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                        hasPlayerThought = true;
                        break;
                    case 4:
                        thoughtBarText.Add("The only thing that's impossible is me understanding what the hell this dream is.");
                        thoughtBarText.Add("I guess I just gotta burn the time til I wake up.");
                        thoughtBarText.Add("There's that cloud again.");
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                        hasPlayerThought = true;
                        break;
                    case 7:
                        thoughtBarText.Add("I don't even care anymore.");
                        thoughtBarText.Add("I'd rather be reading Faulkner than this...");
                        thoughtBarText.Add("Well... Onwards and upwards.");
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                        hasPlayerThought = true;
                        break;
                }
            }
        }
    }
    #endregion
}
