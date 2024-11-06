using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraLevel2D : MonoBehaviour
{
    [SerializeField] float speed = 6.5f;
    Transform playerLevel2D;
    float yPosPlayer;
    float xPosPlayer;

    private void Awake()
    {
        playerLevel2D = GameObject.Find("Player Level 2D").transform;
    }
    // Camera Movement (large if statement )
    void Update()
    {
        yPosPlayer = playerLevel2D.position.y;
        xPosPlayer = playerLevel2D.position.x;

        // Origin
        if (yPosPlayer > -5.2 && yPosPlayer < 5.2 && xPosPlayer > -9.13 && xPosPlayer < 9.13)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, -10), speed * Time.deltaTime);            
        }
        // Right tunnel
        else if (yPosPlayer > -5.2 && yPosPlayer < 5.2 && xPosPlayer >= 9.13 && xPosPlayer <= 26.655)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(17.788f, 0, -10), speed * Time.deltaTime);
        }
        // Right area
        else if (yPosPlayer > -5.2 && yPosPlayer < 5.2 && xPosPlayer > 26.65)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(17.788f * 2, 0, -10), speed * Time.deltaTime);
        }
        // Right-Top area
        else if (yPosPlayer >= 5.2 && xPosPlayer > 26.65)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(17.788f * 2, 10, -10), speed * Time.deltaTime);
        }
        // Bottom tunnel
        else if (yPosPlayer >= -15.1 && yPosPlayer <= -5.2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -10, -10), speed * Time.deltaTime);
        }
        // Bottom area
        else if (yPosPlayer < -15.1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -20, -10), speed * Time.deltaTime);
        }
        // Top area
        else if (yPosPlayer >= 5.2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 10, -10), speed * Time.deltaTime);
        }
        // Left tunnel
        else if (xPosPlayer >= -26.65 && xPosPlayer <= -9.13)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-17.788f, 0, -10), speed * Time.deltaTime);
        }
        // Left area
        else if (xPosPlayer < -26.65)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-17.788f * 2, 0, -10), speed * Time.deltaTime);
        }
    }
}
