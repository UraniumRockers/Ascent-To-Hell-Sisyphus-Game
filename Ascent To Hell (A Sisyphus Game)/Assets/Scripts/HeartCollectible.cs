using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartCollectible : MonoBehaviour
{
    private Animator animator;
    private float health;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Heart Collectible");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
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
            HealthManager2DAndBossfight.DetermineSetHearts(health - 1);
            if (sceneIndex == 1)
            {
                List<string> thoughtText = new();
                thoughtText.Add("Woah. Don't know what that was, but I feel a bit better now.");
                thoughtText.Add("I think I'm ready to \"start that challenge\" now");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                PlayerLevel2D.isPlayerPrepared = true;
            }
            Destroy(gameObject);
        }
    }
}
