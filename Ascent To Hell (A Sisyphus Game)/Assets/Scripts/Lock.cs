using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

public class Lock : MonoBehaviour
{
    public static bool canPlayerMove = true;

    private GameObject lockCanvas;
    private bool keyDown = false;
    private bool isCompleted = false;
    private List<TMP_Text> dropdownText = new();
    private List<GameObject> images = new();

    void Start()
    {
        canPlayerMove = true;

        images.Add(GameObject.Find("Locked Image"));
        images.Add(GameObject.Find("Unlocked Image"));
        lockCanvas = GameObject.Find("Combination Lock Canvas");
        DefineVariables();

        images[1].SetActive(false);
        lockCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyDown = true;
            print("E is pressed");
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            keyDown = false;
            print("E is no longer pressed");
        }

        canPlayerMove = !lockCanvas.activeSelf;

        if (dropdownText.Count == 3)
        {
            if (lockCanvas.activeSelf && dropdownText[0].text == "1" && dropdownText[1].text == "4" && dropdownText[2].text == "2")
            {
                images[0].SetActive(false);
                images[1].SetActive(true);
                isCompleted = true;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ALSO THE THOUGHT TEXT WHEN RE-ENTERING THE TRIGGER IN FRONT OF DOOR DOESN'T WORK

        if (collision.CompareTag("Player") && keyDown)
        {
            if (isCompleted)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue down the tunnel");
                gameObject.SetActive(false);
                DoorRotationScript.OpenDoor();
                print("Door should open");
            }
            lockCanvas.SetActive(!lockCanvas.activeSelf);
        }
    }

    private void DefineVariables()
    {
        dropdownText.Clear();

        if (lockCanvas.activeSelf)
        {
            print($"images list is {images.Count} items long");

            for (int i = 1; i < 4; i++)
            {
                dropdownText.Add(GameObject.Find($"Num {i} Dropdown").GetComponentInChildren<TMP_Text>());
            }
            print($"dropdownText list is {dropdownText.Count} items long");
        }
    }

}
