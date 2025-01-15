using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelBoulder : MonoBehaviour
{
    public static bool canPlayerMove = true;
    private bool loadScreen = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPlayerMove = false;
            loadScreen = true;
        }
    }
    private void Start()
    {
        canPlayerMove = true;
    }
    private void FixedUpdate()
    {
        if (loadScreen)
        {
            LoadingScreen.LoadScreen();
        }
    }

}
