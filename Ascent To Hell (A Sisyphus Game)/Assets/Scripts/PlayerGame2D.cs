using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGame2D : MonoBehaviour
{
    public static bool didPlayerFail = false;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float smallScale = 0.8f;
    [SerializeField] private float bigScale = 1f;
    private Rigidbody2D rb;
    private int sceneIndex;
    private float maxAlt = 0;
    private float minAlt = -4.99f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        didPlayerFail = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        ObjectiveManager2DAndBossfight.Change2DObjectiveText("Reach 1000m");
        switch (sceneIndex)
        {
            case 2:
                HealthManager2DAndBossfight.Set1_5Hearts();
                break;
            case 5:
                HealthManager2DAndBossfight.Set2_5Hearts();
                break;
            case 8:
                HealthManager2DAndBossfight.Set3_5Hearts();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!didPlayerFail)
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
        }

        float t = Mathf.InverseLerp(minAlt, maxAlt, transform.position.y);
        float scale = Mathf.Lerp(bigScale, smallScale, t);
        transform.localScale = new Vector2(scale, scale);

        if (HealthManager2DAndBossfight.health == -.5)
        {
            didPlayerFail = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wind"))
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
        }
    }

}
