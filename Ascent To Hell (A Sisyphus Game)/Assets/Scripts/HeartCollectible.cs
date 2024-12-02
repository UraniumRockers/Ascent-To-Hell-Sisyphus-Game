using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartCollectible : MonoBehaviour
{
    private Animator animator;
    private float health;
    private BoxCollider2D trigger;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Heart Collectible");
        trigger = GetComponent<BoxCollider2D>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        health = HealthManager2DAndBossfight.health;
        Destroy(trigger);
        trigger = gameObject.AddComponent<BoxCollider2D>();
        trigger.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthManager2DAndBossfight.DetermineSetHearts(health - 1);
            if (sceneIndex == 1)
            {
                List<string> thoughtText = new();
                thoughtText.Add("Woah. That was weird. Didn't feel too bad though.");
                thoughtText.Add("I think I'm ready for that \"challenge\" now.");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
            }
            Destroy(gameObject);
        }
    }
}
