using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BlackScreenManager : MonoBehaviour
{
    private float waitTime = 2;
    private static float initialTime;
    private bool loadScreen = false;
    private static bool check = false;


    public static void EndGame()
    {
        initialTime = Time.time;
        check = true;
    }
    private void Update()
    {
        if (check)
        {
            if (Time.time - initialTime >= waitTime)
            {
                loadScreen = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (loadScreen)
        {
            LoadingScreen.LoadScreen();
        }
    }


}
