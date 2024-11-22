using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotationScript: MonoBehaviour
{
    private List<string> thoughtText;
    private static GameObject doorRotationPoint;

    private void Start()
    {
        doorRotationPoint = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("pls dont crash");
        //thoughtText.Add("Really? A locked door? Man...");
        //thoughtText.Add("Looks like a combination lock with 4 numbers...");
        //ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
        OpenDoor();
    }

    public static void OpenDoor()
    {
        print("plz work");
        doorRotationPoint.GetComponent<BoxCollider2D>().enabled = false;

        while (doorRotationPoint.transform.rotation.z <= 90)
        {
            doorRotationPoint.transform.Rotate(0f, 0f, 15 * Time.deltaTime, Space.Self);
        }

    }
}
