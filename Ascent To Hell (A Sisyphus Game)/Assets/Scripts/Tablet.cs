using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Tablet : MonoBehaviour
{
    public static bool shouldPlayerMove = true;

    //BoxCollider2D originBoxCollider = GameObject.Find("Origin").GetComponent<BoxCollider2D>();
    GameObject tabletCanvas; 
    TMP_Text tabletText;
    bool keyDown = false;
    bool activatedForFirstTime = false;
    // MAKE THE BOX COLLIDER FOR THE RED CLOUD DISAPPEAR AFTER IT IS ACTIVATED FOR THE FIRST TIME

    private void Awake()
    {
        tabletCanvas = GameObject.Find("Level 1 Tablet Canvas");
        tabletText = tabletCanvas.GetComponentsInChildren<TMP_Text>()[0];
        tabletText.text = "This is your new life. Explore while you still have the chance. When you are ready, venture upwards. The path will reveal itself, and the pressure plate to summon your punishment will be visible.";
        tabletCanvas.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyDown = true;
        }
        shouldPlayerMove = !tabletCanvas.activeSelf;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyDown)
        {
            tabletCanvas.SetActive(!tabletCanvas.activeSelf);
            keyDown = false;
        }
    }
}
