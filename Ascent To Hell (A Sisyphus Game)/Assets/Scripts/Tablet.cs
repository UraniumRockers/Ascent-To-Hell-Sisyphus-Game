using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Tablet : MonoBehaviour
{
    public static bool shouldPlayerMove = true;          // Stops player movement if the tip screen is out

    BoxCollider2D originBottomBoxCollider;               // Box collider that blocks the bottom entrance
    GameObject tabletCanvas;                             // Canvas that shows tablet when interacted
    GameObject redCloudBottom;
    TMP_Text tabletText;                                 // Tablet tip text
    bool keyDown = false;                                // Has 'E' been pressed

    private void Awake()
    {
        #region Defining Variables
        // Defining the variables
        tabletCanvas = GameObject.Find("Tablet Canvas");
        tabletText = tabletCanvas.GetComponentsInChildren<TMP_Text>()[0];
        tabletCanvas.SetActive(false);
        originBottomBoxCollider = GameObject.Find("Origin").GetComponent<BoxCollider2D>();
        redCloudBottom = GameObject.Find("Red Cloud (Bottom)");
        #endregion
        #region Setting Text
        // Deciding what the tablet to say based on the scene
        /// THIS MIGHT NOT WORK YET BECAUSE I DIDN'T TEST IT YET
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
        // Disabling red cloud
        redCloudBottom.SetActive(false);
    }

    #region Check For Button Press
    private void Update()
    {
        // Checks every frame to see if E is down or not
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyDown = true;
            print("Key was pressed");
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
        if (collision.gameObject.CompareTag("Player") && keyDown)
        {
            // Enables/disables canvas and removes disables box collider, allowing the player to go down
            tabletCanvas.SetActive(!tabletCanvas.activeSelf);
            keyDown = false;
            originBottomBoxCollider.enabled = false;
            redCloudBottom.SetActive(true);
        }
    }
    #endregion
}
