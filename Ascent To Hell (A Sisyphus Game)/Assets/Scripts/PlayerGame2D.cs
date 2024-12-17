using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGame2D : MonoBehaviour
{
    public static bool didPlayerFail = false;
    public static bool didPlayerWin = false;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float smallScale = 0.8f;
    [SerializeField] private float bigScale = 1f;
    private Rigidbody2D rb;
    private int sceneIndex;
    private float maxAlt = 0;
    private float minAlt = -4.99f;
    private int targetAlt;
    private bool hasPlayerFallen = false;


    // Start is called before the first frame update
    void Start()
    {
        print("Start happens");
        rb = GetComponent<Rigidbody2D>();
        hasPlayerFallen = false;
        didPlayerWin = false;
        didPlayerFail = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //ObjectiveManager2DAndBossfight.Change2DObjectiveText("Reach 1000m");
        switch (sceneIndex)
        {
            case 2:
                //HealthManager2DAndBossfight.Set1_5Hearts();
                targetAlt = 333;
                break;
            case 5:
                //HealthManager2DAndBossfight.Set2_5Hearts();
                targetAlt = 666;
                break;
            case 8:
                //HealthManager2DAndBossfight.Set3_5Hearts();
                targetAlt = 999;
                break;
        }
        print($"Target alt: {targetAlt}");

    }

    // Update is called once per frame
    void Update()
    {
        if (!didPlayerWin && !hasPlayerFallen && HealthManager2DAndBossfight.health == -.5f && AltitudeCanvasManager2D.altitude <= targetAlt)
        {
            didPlayerFail = true;
            Fall();

        }
        if (didPlayerWin)
        {
            if (rb != null)
            {
                Fall();
                Destroy(rb);
            }

        }
        


        if (!didPlayerFail && !didPlayerWin)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y <= 0)
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.up;
            }
            if (Input.GetKey(KeyCode.S) && transform.position.y >= -4.99)
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.down;
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x <= 6)
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.right;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x >= -6)
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.left;
            }


            float t = Mathf.InverseLerp(minAlt, maxAlt, transform.position.y);
            float scale = Mathf.Lerp(bigScale, smallScale, t);
            transform.localScale = new Vector2(scale, scale);
        }

        if (HealthManager2DAndBossfight.health < -.5 && AltitudeCanvasManager2D.altitude > targetAlt && !didPlayerFail)
        {
            didPlayerWin = true;
            print("game won");
            print($"healht less than -.5? {HealthManager2DAndBossfight.health < -.5}");
            print($"Altitude high enough? {AltitudeCanvasManager2D.altitude > targetAlt} and targetAlt is {targetAlt}");
            print($"didPlayerFail? {didPlayerFail}");
            AltitudeCanvasManager2D.altitude = targetAlt;
            HealthManager2DAndBossfight.DetermineSetHearts(-.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wind") && !didPlayerFail)
        {
            if (collision.gameObject.transform.eulerAngles.y == 180)
            {
                rb.AddForce(new Vector2(-Random.Range(750, 1500), 0));
            }
            else
            {
                rb.AddForce(new Vector2(Random.Range(750, 1500), 0));
            }
            print("Force was added");
            rb.velocity = Vector3.zero;
        }
    }


    private void Fall()
    {
        GameObject.Find("Sky").GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        //rb.drag = 0f;
        rb.gravityScale = 1f;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.angularDrag = 0.05f;
        rb.drag = 0;
        rb.freezeRotation = false;
        //int addedForce = Random.Range(15, 20);
        //Vector2 force = new Vector2(Random.Range(-750, 1500), Random.Range(750, 1250));
        Vector2 force = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
        //print($"Force applied: {force}");
        rb.AddForce(force);
        //print($"Player force: {addedForce}");
        hasPlayerFallen = true;
    }

}
