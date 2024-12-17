using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private Vector2 spawnPoint;
    private Vector2 targetPoint;
    private float speed;
    private bool collided;
    private Vector2[] spawnPoints = { new Vector2(-1.69f, 6f), new Vector2(0, 6f), new Vector2(1.59f, 6) };
    private Vector2[] targetPoints = { new Vector2(-5.95f, -6), new Vector2(0, -6), new Vector2(5.85f, -6) };

    // Start is called before the first frame update
    void Start()
    {
        collided = false;
        speed = Random.Range(3, 6);
        int index = Random.Range(0, 3);
        spawnPoint = spawnPoints[index];
        targetPoint = targetPoints[index];
        transform.position = spawnPoint;
        gameObject.AddComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print($"Debris Count: {DebrisSpawner.debrisCount}");
        float t = Mathf.InverseLerp(-6, 6, transform.position.y);
        float scale = Mathf.Lerp(2.25f, 1f, t);
        transform.localScale = new Vector2(scale, scale);

        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -.5f));

        if (transform.position.y <= -6 || PlayerGame2D.didPlayerFail || PlayerGame2D.didPlayerWin)
        {
            DebrisSpawner.debrisCount--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collided)
        {
            DebrisSpawner.debrisCount--;
            collided = true;
            print("debris count reduced");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collided && collision.CompareTag("Boulder"))
        {
            collided = true;
            //print($"Debris Hit {collision.tag}");
            if (HealthManager2DAndBossfight.health != -.5f)
            {
                HealthManager2DAndBossfight.DetermineSetHearts(HealthManager2DAndBossfight.health + 1);
                //print("Health decreased");
            }
            DebrisSpawner.debrisCount--;
            print("debris count reduced");
            Destroy(gameObject);
        }
    }

}
