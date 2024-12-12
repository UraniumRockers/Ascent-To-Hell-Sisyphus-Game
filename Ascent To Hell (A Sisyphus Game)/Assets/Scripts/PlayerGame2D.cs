using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame2D : MonoBehaviour
{
    public static bool didPlayerFail = false;

    [SerializeField] private float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        didPlayerFail = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y <= -1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -4.99)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 5.22)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -5.04)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

    }
}
