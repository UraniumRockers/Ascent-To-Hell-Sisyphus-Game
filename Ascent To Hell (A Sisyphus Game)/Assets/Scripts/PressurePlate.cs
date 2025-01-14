using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{
    public static bool canPlayerMove = true;

    private bool hasStuffHappenedAlready = false;
    private List<string> thoughtText = new();
    private Animator animator;
    private int sceneIndex;

    private void Start()
    {
        animator = GameObject.Find("Boulder").GetComponent<Animator>();
        animator.enabled = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasStuffHappenedAlready && gameObject.name == "Pressure Plate")
        {
            canPlayerMove = false;
            animator.enabled = true; 
            animator.Play("Boulder Roll Down");
            hasStuffHappenedAlready = true;
            GameObject.Find("Player Level 2D").GetComponents<AudioSource>()[4].Play();
            print("Boulder Sound Plays");
        }
    }

    public void AnimationEnd()
    {
        PressurePlate.canPlayerMove = true;
        animator.enabled = false;
        switch (sceneIndex) 
        {
            case 1:
                thoughtText.Add("...");
                thoughtText.Add("Am... am I supposed to push that?");
                thoughtText.Add("Well... nothing else to do, I guess.");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                break;
            case 4:
                thoughtText.Add("I got this.");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                break;
            case 7:
                thoughtText.Add("Maybe it won't be so bad this time...?");
                thoughtText.Add("*sigh*");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
                break;
        }
        ObjectiveManager2DAndBossfight.Change2DObjectiveText("Push the boulder.");


    }
}
