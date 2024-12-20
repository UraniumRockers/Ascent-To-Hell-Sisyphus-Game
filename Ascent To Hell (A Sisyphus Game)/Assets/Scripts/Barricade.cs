using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barricade : MonoBehaviour
{
    private GameObject[] barricades = new GameObject[3];
    private int swingCounter = 0;
    private bool hasPlayerEnteredForFirstTime = false;
    private List<string> thoughtText = new();
    private bool hasObjectiveTextBeenChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        hasObjectiveTextBeenChanged = false;
        hasPlayerEnteredForFirstTime = false;
        barricades[0] = GameObject.Find("Barricade 0");
        barricades[1] = GameObject.Find("Barricade 1");
        barricades[2] = GameObject.Find("Barricade 2");

        barricades[1].SetActive(false);
        barricades[2].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //print($"Barricade has been swung {swingCounter} times");
        switch (swingCounter)
        {
            case 2:
                barricades[0].SetActive(false);
                barricades[1].SetActive(true);
                break;
            case 4:
                barricades[1].SetActive(false);
                barricades[2].SetActive(true);
                gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
                GameObject.Find("2D Controls").GetComponent<TMP_Text>().text = "W: Up\nA: Left\nS: Down\nD: Right\nE: Interact\nSpace: Throw Pebble";

                if (!hasObjectiveTextBeenChanged)
                {
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue down the tunnel.");
                    hasObjectiveTextBeenChanged = true;
                    GameObject.Find("Hatchet Tool").SetActive(false);

                    if (SceneManager.GetActiveScene().buildIndex == 4)
                    {
                        List<string> thoughtText = new()
                        {
                            "Nice, that worked.",
                            "I'll keep this hatchet for later."
                        };
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                    }
                }
                break;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasPlayerEnteredForFirstTime)
        {
            ObjectiveManager2DAndBossfight.Change2DObjectiveText("Take down the barricade.");
            if (SceneManager.GetActiveScene().buildIndex == 4) 
            {
                thoughtText.Add("I definitely can't get passed that.");
                thoughtText.Add("If I can find something to tear it down...");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
            }
            hasPlayerEnteredForFirstTime = true;
            gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hatchet") && Hatchet2D.isSwinging && hasPlayerEnteredForFirstTime)
        {
            swingCounter++;
            Hatchet2D.isSwinging = false;
        }
    }
}
