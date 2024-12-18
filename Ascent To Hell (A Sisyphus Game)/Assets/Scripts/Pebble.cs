using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : MonoBehaviour
{
    [SerializeField] GameObject pebble;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player Level 2D")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(pebble, GameObject.Find("Player Level 2D").transform.position, Quaternion.Euler(0, 0, Random.Range(0, 361)));
            }
        }
        else if (gameObject.name == "Pebble(Clone)")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(2, 10), Random.Range(2, 10)));
        }
    }
}
