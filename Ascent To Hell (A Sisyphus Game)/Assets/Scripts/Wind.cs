using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wind : MonoBehaviour
{
    private float windSpeed;
    private int sceneIndex;
    private bool collided;
    //private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        collided = false;
        //rb = gameObject.GetComponent<Rigidbody2D>();
        gameObject.AddComponent<PolygonCollider2D>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 2:
                windSpeed = Random.Range(2, 5);
                break;
            case 5:
                windSpeed = Random.Range(3, 6);
                break;
            case 8:
                windSpeed = Random.Range(4, 7);
                break;
        }


        switch (transform.position.y)
        {
            case 1.7f:
                transform.localScale = Vector3.one * .8f;
                break;
            case -.78f:
                transform.localScale = Vector3.one * .9f;
                break;
            case -3.64f:
                transform.localScale = Vector3.one;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.eulerAngles.y == 180)
        {
            if (gameObject.transform.position.x >= -10.85)
            {
                gameObject.transform.position += windSpeed * Time.deltaTime * Vector3.left;
            }
            else
            {
                WindSpawner.windCount--;
                Destroy(gameObject);
                //print("Wind was destroyed");
            }
        }
        else
        {
            if (gameObject.transform.position.x <= 10.85)
            {
                gameObject.transform.position += windSpeed * Time.deltaTime * Vector3.right;
            }
            else
            {
                WindSpawner.windCount--;
                Destroy(gameObject);
                //print("Wind was destroyed");
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Boulder"))
        //{
        //    WindSpawner.windCount--;
        //    Destroy(gameObject);
        //}
        if (collision.gameObject.CompareTag("Player") && !collided)
        {
            collided = true;
            WindSpawner.windCount--;
            print("wind count reduced");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boulder") && !collided)
        {
            //print($"Wind Hit {collision.tag}");
            collided = true;
            if (HealthManager2DAndBossfight.health != -.5f)
            {
                HealthManager2DAndBossfight.DetermineSetHearts(HealthManager2DAndBossfight.health + 1);
                //print("Health decreased");
            }
            WindSpawner.windCount--;
            print("wind count reduced");
            Destroy(gameObject);
        }
    }
}
