using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCloudScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ObjectiveManager2DAndBossfight.Change2DObjectiveText("Continue down the tunnel.");
            gameObject.GetComponents<BoxCollider2D>()[0].enabled = false;
        }
    }
}
