using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTunnelSoliloquy : MonoBehaviour
{
    private bool hasAlreadyYapped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasAlreadyYapped)
        {
            List<string> thoughtText = new();
            thoughtText.Add("I don't like this.");
            int randNum = Random.Range(0, 26);
            if (randNum == 0)
            {
                thoughtText.Add("But I won't let it burn out!");
            }
            ThoughtCanvasManager2D.SetThoughtBarText(thoughtText);
            hasAlreadyYapped = true;
        }
    }
}
