using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : MonoBehaviour
{
    [SerializeField] GameObject pebble;
    private GameObject player;
    private bool hasBeenLaunched = false;
    //private bool pebbleTouchingPlayer = false;

    private void Start()
    {
        player = GameObject.Find("Player Level 2D");
    }

    void Update()
    {
        if (gameObject.name == "Player Level 2D")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(pebble, transform.position, transform.rotation);
            }
        }
        else if (gameObject.name == "Pebble(Clone)" && !hasBeenLaunched)
        {
            player.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(player.transform.rotation * Vector2.up * Random.Range(10, 25), ForceMode2D.Impulse);
            hasBeenLaunched = true;
            player.GetComponent<PolygonCollider2D>().enabled = true;
            StartCoroutine(Destroy());
        }
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
