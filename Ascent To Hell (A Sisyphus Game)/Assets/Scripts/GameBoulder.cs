using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBoulder : MonoBehaviour
{
    private GameObject playerBoulder;
    private GameObject fallingBoulder;
    private Animator playerBoulderAnim;
    private Animator fallingBoulderAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerBoulder = GameObject.Find("Player Boulder");
        fallingBoulder = GameObject.Find("Falling Boulder");
        fallingBoulder.GetComponent<SpriteRenderer>().enabled = false;
        
        playerBoulderAnim = playerBoulder.GetComponent<Animator>();
        fallingBoulderAnim = fallingBoulder.GetComponent<Animator>();
        fallingBoulderAnim.Play("Boulder Roll");
        playerBoulderAnim.Play("Boulder Roll");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BoulderRoll()
    {
        transform.rotation = transform.Rotate(0, 0, -.1f, 1);
    }
}
