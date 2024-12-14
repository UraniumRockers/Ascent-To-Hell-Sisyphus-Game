using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBoulder : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private GameObject playerBoulder;
    private GameObject fallingBoulder;
    private Animator playerBoulderAnim;
    private Animator fallingBoulderAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerBoulder = GameObject.Find("Player Boulder");
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
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Wind") && HealthManager2DAndBossfight.health != -.5f)
    //    {
    //        HealthManager2DAndBossfight.DetermineSetHearts(HealthManager2DAndBossfight.health++);
    //        print("Health Decreased");
    //    }
    //    print("Collided");
    //}
}
