using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBoulder : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private Rigidbody2D rbParent;
    private GameObject playerBoulder;
    private GameObject fallingBoulder;
    private Animator playerBoulderAnim;
    private Animator fallingBoulderAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerBoulder = GameObject.Find("Player Boulder");
        rbParent = gameObject.GetComponentInParent<Rigidbody2D>();
        //fallingBoulder = GameObject.Find("Falling Boulder");
        //fallingBoulder.GetComponent<SpriteRenderer>().enabled = false;

        //playerBoulderAnim = playerBoulder.GetComponent<Animator>();
        //fallingBoulderAnim = fallingBoulder.GetComponent<Animator>();
        //fallingBoulderAnim.Play("Boulder Roll");
        //playerBoulderAnim.Play("Boulder Roll");

        /// WILL PROBABLY MAKE IT SO THAT THE FAILING BOULDER GETS CREATED AFTER GAME ENDS WITH ROTATION AND SCALE VALUES OF THE GAME BOULDER SO NO LOOK WEIRD
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.World);
        //if (gameObject.name == "Falling Bolder" && !PlayerGame2D.didPlayerFail)
        //{
        //    transform.position = playerBoulder.transform.position;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
