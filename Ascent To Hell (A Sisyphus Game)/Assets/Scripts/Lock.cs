using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

public class Lock : MonoBehaviour
{
    public static bool canPlayerMove = true;

    private GameObject lockCanvas;
    private GameObject canvas;
    private bool keyDown = false;
    private bool isCompleted = false;
    private List<TMP_Text> dropdownText = new();
    private List<GameObject> images = new();
    //private string[] values = new string[3];


    void Start()
    {
        canPlayerMove = true;

        images.Add(GameObject.Find("Locked Image"));
        images.Add(GameObject.Find("Unlocked Image"));
        lockCanvas = GameObject.Find("Lock Canvas Components");
        canvas = GameObject.Find("Combination Lock Canvas");

        /*for (int i = 0; i < 3; i++)
        {
            randomNums.Add(Random.Range(0, 10));
        }*/

        DefineVariables();

        images[1].SetActive(false);
        lockCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyDown = true;
            //print("E is pressed");
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            keyDown = false;
            //print("E is no longer pressed");
        }

        canPlayerMove = !lockCanvas.activeSelf;

       /* for (int i = 0; i < 3; i++)
        {
            values[i] = dropdownText[i].text;
        }*/

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

        if (collision.CompareTag("Player") && keyDown)
        {
            lockCanvas.SetActive(!lockCanvas.activeSelf);
            canvas.GetComponent<Canvas>().sortingOrder = (lockCanvas.activeSelf) ? 20 : 0;
            /*for (int i = 0; i < 3; i++) 
            {
               dropdownText[i] = values[i];
            }*/
            keyDown = false;
            if (isCompleted)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue down the tunnel");
                gameObject.SetActive(false);
                DoorRotationScript.OpenDoor();
                GameObject.Find("Player Level 2D").GetComponents<AudioSource>()[2].Play();
                print("door opening sound plays");
                //print("Door should open");
                canPlayerMove = true;
            }
            
        }
    }

    private void DefineVariables()
    {
        //print("This happened");
        dropdownText.Clear();

        if (lockCanvas.activeSelf)
        {
            //print($"images list is {images.Count} items long");

            for (int i = 1; i < 4; i++)
            {
                TMP_Text text = GameObject.Find($"Num {i} Dropdown").GetComponentInChildren<TMP_Text>();
                //text.text = $"{text.GetComponentInParent<TMP_Dropdown>().options[Random.Range(0, 10)].text}";
                //print($"The parent has {text.GetComponentInParent<TMP_Dropdown>().options.Count} options");
                dropdownText.Add(text);
            }

            //print($"dropdownText list is {dropdownText.Count} items long");

        }
    }

}
