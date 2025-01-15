using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
//using Unity.VisualScripting;
using UnityEngine;

public class GameBoulder : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private Rigidbody2D rbParent;
    private GameObject playerBoulder;
    private Vector3 failPoint;
    private Vector3 failScale;
    private GameObject failCanvas;
    private bool isFalling = false;
    private float initialTime;
    private GameObject blackCanvas;

    // Start is called before the first frame update
    void Start()
    {
        blackCanvas = GameObject.Find("Black Canvas");
        blackCanvas.SetActive(false);
        //didPlayerFailRightNow = false;
        playerBoulder = GameObject.Find("Player Boulder");
        rbParent = gameObject.GetComponentInParent<Rigidbody2D>();

        failCanvas = GameObject.Find("Fail Canvas");
        failCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerGame2D.didPlayerFail && !PlayerGame2D.didPlayerWin)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.World);
            failPoint = transform.position;
            failScale = transform.localScale;
            isFalling = false;

        }
        else if (PlayerGame2D.didPlayerFail && !PlayerGame2D.didPlayerWin)
        {
            Fall();

            if (transform.position.y <= -9)
            {
                failCanvas.SetActive(true);
                failCanvas.GetComponentInChildren<TMP_Text>().text = $"Altitude: {AltitudeCanvasManager2D.altitude}/1000m";
                
            }
            //float t = Mathf.InverseLerp(-6, failPoint.y, transform.position.y);
            //float scale = Mathf.Lerp(.99f, failScale.x, t);
            //transform.localScale = new Vector2(scale, scale);
        }

        else if (!PlayerGame2D.didPlayerFail && PlayerGame2D.didPlayerWin)
        {
            if (gameObject.GetComponent<Rigidbody2D>() == null && !isFalling)
            {
                Fall();
                isFalling = true;
                initialTime = Time.time;
            }
            else
            {
                if (gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    //print("rb destroyed");
                }
                float waitTime = 3;
                if (Time.time - initialTime >= waitTime)
                {
                    blackCanvas.SetActive(true);
                    BlackScreenManager.EndGame();
                    Destroy(gameObject.GetComponent<GameBoulder>());
                }
            }


        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerGame2D.didPlayerFail)
        {
            if (collision.CompareTag("Wind"))
            {
                if (collision.gameObject.transform.eulerAngles.y == 180)
                {
                    rbParent.AddForce(new Vector2(-Random.Range(750, 1500), 0));
                }
                else
                {
                    rbParent.AddForce(new Vector2(Random.Range(750, 1500), 0));
                }
            }
            else if (collision.CompareTag("Debris"))
            {
                rbParent.AddForce(new Vector2(0, -Random.Range(1000, 2000)));
            }
        }
        
    }

    private void Fall()
    {
        gameObject.layer = 5;

        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            Vector3 worldPos = transform.position;
            transform.parent = null;
            transform.position = worldPos;
            gameObject.AddComponent<Rigidbody2D>();
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            print("rb created");
            rb.mass = 100;
            rb.AddForce(new Vector2(Random.Range(80, 101) / 100 * 50000, 35000));
            //rb.AddForce(new Vector2(Random.Range(80, 101) / 100 * (Random.Range(-1, 2) * 50000), 35000));
        }
    }

}
