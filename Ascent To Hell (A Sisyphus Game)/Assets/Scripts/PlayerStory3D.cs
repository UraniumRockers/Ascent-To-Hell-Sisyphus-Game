using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager;

//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStory3D : MonoBehaviour
{
    public static bool canPlayerMove;

    private static bool isCopAttackOver = false;

    [SerializeField] private float speed;
    [SerializeField] private GameObject redScreen;
    [SerializeField] private Animation copAttack;
    [SerializeField] private GameObject health0;
    [SerializeField] private GameObject health1;
    private int sceneIndex;
    private float playerRotationX;
    private bool hasAnimStarted;
    private bool shouldPlayerLookBack;
    private bool hasRedScreenFinished;
    private bool isPlayerHoldingBat;
    private bool hasPlayerTurnedBack;

    // Start is called before the first frame update
    void Start()
    {
        print(transform.rotation.y);
        GameObject.Find("Baseball Bat").GetComponent<Rigidbody>().useGravity = false;
        //print("Gravity is false");

        if (gameObject.name == "Player")
        {
            hasRedScreenFinished = false;
            isCopAttackOver = false;
            hasAnimStarted = false;
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            playerRotationX = transform.rotation.x;
            isPlayerHoldingBat = false;
            shouldPlayerLookBack = false;
            hasPlayerTurnedBack = false;

            switch (sceneIndex)
            {
                case 3:
                    ObjectiveManager3D.SetObjectiveText("Get out of here.");
                    canPlayerMove = true;
                    break;
                case 6:
                    ObjectiveManager3D.SetObjectiveText("Drop it.");
                    canPlayerMove = false;
                    isPlayerHoldingBat = true;
                    break;
                case 9:
                    ObjectiveManager3D.SetObjectiveText("What have you done...");
                    canPlayerMove = false;
                    shouldPlayerLookBack = true;
                    break;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player")
        {
            if (canPlayerMove)
            {
                if (Input.GetKey(KeyCode.W) && transform.position.z <= 11.5)
                {
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.S) && transform.position.z >= -8.468307)
                {
                    transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                }
            }
            if (shouldPlayerLookBack)
            {

                
            }


            if (isPlayerHoldingBat)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    //print("Gravity is true");
                    GameObject.Find("Baseball Bat").GetComponent<Rigidbody>().useGravity = true;
                    canPlayerMove = true;
                    ObjectiveManager3D.SetObjectiveText("Get out of here.");
                }
            }

            if (transform.position.z >= 11.5)
            {
                GameObject cop = GameObject.Find("Cop With Baton Anim");
                if (cop.transform.position.z > 13.5)
                {
                    canPlayerMove = false;
                    cop.transform.Translate(new Vector3(0, 0, 0.5f));
                }
                else
                {
                    cop.transform.position = new Vector3(0, -.8f, 13.5f);
                    cop.GetComponent<Animator>().Play("CopAttack");
                    ObjectiveManager3D.SetObjectiveText("They know.");
                }
                if (isCopAttackOver)
                {
                    print("done");
                }

            }

            if (isCopAttackOver)
            {
                
                health1.SetActive(false);
                health0.SetActive(true);
                //print(transform.rotation.x);
                if (transform.rotation.x > playerRotationX - .5 && !hasRedScreenFinished)
                {
                    //print("Rotate");
                    if (!hasAnimStarted)
                    {
                        redScreen.GetComponent<Animator>().Play("Red Screen");

                    }
                    transform.Rotate(new Vector3(-30 * Time.deltaTime, -5 * Time.deltaTime, -5 * Time.deltaTime));
                    //print("player rotated");
                }
            }
        }

    }

    public void CopAttackOver()
    {
        isCopAttackOver = true;
    }

    public void RedScreenOver()
    {
        //print("this ran");
        hasRedScreenFinished = true;
        SceneManager.LoadScene(4);
    }

}
