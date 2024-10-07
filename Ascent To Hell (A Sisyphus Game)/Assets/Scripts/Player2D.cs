using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += speed * Time.deltaTime * new Vector3(1, 1, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * -45), 200f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += speed * Time.deltaTime * new Vector3(-1, 1, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 45), 200f);
            }
            else
            {
                transform.position += speed * Time.deltaTime * Vector3.up;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.zero), 200f);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += speed * Time.deltaTime * new Vector3(1, -1, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * -135), 200f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += speed * Time.deltaTime * new Vector3(-1, -1, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 135), 200f);
            }
            else
            {
                transform.position += speed * Time.deltaTime * Vector3.down;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 180), 200f);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * -90), 200f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 90), 200f);
        }
    }
}
