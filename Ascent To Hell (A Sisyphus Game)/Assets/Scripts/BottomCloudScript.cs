using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (gameObject.name)
            {
                case "Red Cloud (Bottom)":
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue down the tunnel.");
                    break;
                case "Red Cloud (Left)":
                    ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue down the tunnel.");
                    break;
            }
            gameObject.GetComponents<BoxCollider2D>()[1].enabled = false;
        }
    }
}
