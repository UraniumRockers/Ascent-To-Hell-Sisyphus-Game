using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel2D : MonoBehaviour
{
    [SerializeField] float speed = 6.5f;
    Transform playerLevel2D;

    private void Awake()
    {
        playerLevel2D = GameObject.Find("Player Level 2D").transform;
    }
    void Update()
    {
        if (playerLevel2D.position.y <= -5.2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -10, -10), speed * Time.deltaTime);
        }
        //else if (playerLevel2D > 5.2 && playerLevel2D)
    }
}
