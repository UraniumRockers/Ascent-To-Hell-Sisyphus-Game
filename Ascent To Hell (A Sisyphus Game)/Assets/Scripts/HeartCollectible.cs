using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartCollectible : MonoBehaviour
{
    private Animator animator;
    private float health;
    private int sceneIndex;
    private GameObject redCloudLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Heart Collectible");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        redCloudLeft = GameObject.Find("Red Cloud (Left)");
    }

    // Update is called once per frame
    void Update()
    {
        health = HealthManager2DAndBossfight.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponents<AudioSource>()[3].Play();
            //print("heart made noise");
            HealthManager2DAndBossfight.DetermineSetHearts(health - 1);
            if (sceneIndex == 1)
            {
                List<string> thoughtText = new()
                {
                    "Woah. Don't know what that was, but I feel a bit better.",
                    "I think I'm ready to do whatever that tablet was talking about now."
                };
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                PlayerLevel2D.isPlayerPrepared = true;
                ObjectiveManager2DAndBossfight.Change2DObjectiveText("Go to the pressure plate.");
            }
            else if (sceneIndex == 4)
            {
                if (gameObject.transform.position.x <= -35)
                {
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Go to the pressure plate.");
                    PlayerLevel2D.isPlayerPrepared = true;
                    List<string> thoughtText = new()
                    {
                        "Oh hey, this again. Nice.",
                        "That boulder doesn't stand a chance.",
                        "...I hope."
                    };
                    ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                }
                else
                {
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue exploring.");
                    redCloudLeft.GetComponents<BoxCollider2D>()[0].enabled = false;
                    redCloudLeft.GetComponents<BoxCollider2D>()[1].enabled = true;
                    redCloudLeft.GetComponent<SpriteRenderer>().enabled = true;
                }
            }

            else if (sceneIndex == 7)
            {
                if (gameObject.transform.position.x <= -35)
                {
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Go to the pressure plate.");
                    PlayerLevel2D.isPlayerPrepared = true;
                }
                else if (gameObject.transform.position.y <= -20)
                {
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue exploring.");
                    redCloudLeft.GetComponents<BoxCollider2D>()[0].enabled = false;
                    redCloudLeft.GetComponents<BoxCollider2D>()[1].enabled = true;
                    redCloudLeft.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Persevere.");
                    List<string> thoughtText = new()
                    {
                        "Another one...",
                        "Yay..."
                    };
                    ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                    GameObject.Find("Right Origin").GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            Destroy(gameObject);
        }
    }
}
