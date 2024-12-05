using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hatchet2D : MonoBehaviour
{
    private GameObject hatchetTool;
    private List<string> thoughtText = new();
    private Animator animator;
    private bool isSwinging = false;

    void Start()
    {
        hatchetTool = GameObject.Find("Hatchet Tool");
        if (gameObject.name != "Hatchet Tool")
        {
            hatchetTool.SetActive(false);
        }
        else
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            thoughtText.Add("Sick, a hatchet.");
            thoughtText.Add("Not the best condition, but I'll take it.");
            ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
            hatchetTool.SetActive(true);
            GameObject.Find("2D Controls").GetComponent<TMP_Text>().text += "Left Click: Swing Hatchet";
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameObject.name == "Hatchet Tool")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isSwinging)
            {
                isSwinging = true;
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
                animator.Play("Hatchet Swing");
                print("Hatchet Swing");
            }

        }
    }

    public void SetAnimationOver()
    {
        isSwinging = false;
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;

    }
}
