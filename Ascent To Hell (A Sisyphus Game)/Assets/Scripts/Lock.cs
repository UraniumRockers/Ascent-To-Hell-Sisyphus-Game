using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;

public class Lock : MonoBehaviour
{
    private GameObject lockCanvas;
    private bool isEPressed = false;
    private List<TMP_Text> dropdownText = new();
    private List<GameObject> images = new();

    void Start()
    {
        lockCanvas = GameObject.Find("Combination Lock Canvas");
        images.Add(GameObject.Find("Locked Image"));
        images.Add(GameObject.Find("Unlocked Image"));
        for (int i = 3; i < 6; i++)
        {
            dropdownText.Add(GameObject.Find($"Num {i - 2} Dropdown").GetComponentInChildren<TMP_Text>());
            // print(dropdownText[i].text);
        }
        images[1].SetActive(false);
        lockCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
            print("E is pressed");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isEPressed = false;
            print("E is no longer pressed");
        }

        if (lockCanvas.activeSelf && dropdownText[0].text == "1" && dropdownText[1].text == "4" && dropdownText[2].text == "2")
        {
            images[0].SetActive(false);
            images[1].SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // CLOSING ITT DOESN'T WORK
        // ALSO NEED TO FREEZE PLAYER MOVEMENT ONCE INTERACTED WITH IT
        // ALSO THE THOUGHT TEXT WHEN RE-ENTERING THE TRIGGER IN FRONT OF DOOR DOESN'T WORK

        if (collision.CompareTag("Player") && isEPressed)
        {
            lockCanvas.SetActive(!lockCanvas.activeSelf);
        }
    }
}
