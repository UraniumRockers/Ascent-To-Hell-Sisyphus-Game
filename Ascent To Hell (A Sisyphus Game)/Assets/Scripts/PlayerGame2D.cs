using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGame2D : MonoBehaviour
{
    public static bool didPlayerFail = false;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float smallScale = 0.8f;
    [SerializeField] private float bigScale = 1f;
    private float maxAlt = 0;
    private float minAlt = -4.99f;


    // Start is called before the first frame update
    void Start()
    {
        didPlayerFail = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 0)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -4.99)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 5.22)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -5.04)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }

        float t = Mathf.InverseLerp(minAlt, maxAlt, transform.position.y);
        float scale = Mathf.Lerp(bigScale, smallScale, t);
        transform.localScale = new Vector2(scale, scale);


    }
}
