
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.PackageManager;

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
    private GameObject bat;
    private float playerRotationX;
    private bool hasAnimStarted;
    private bool shouldPlayerLookBack;
    private bool hasRedScreenFinished;
    private bool isPlayerHoldingBat;
    private bool hasPlayerTurnedBack;
    private AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {


        //print(transform.rotation.y);
        //print("Gravity is false");

        if (gameObject.name == "Player")
        {
            audioSources = gameObject.GetComponents<AudioSource>();
            audioSources[0].volume = MainMenu.volumeScale;
            audioSources[1].volume = MainMenu.volumeScale;
            audioSources[2].volume = MainMenu.volumeScale;

            if (audioSources.Length >= 4)
            {
                audioSources[3].volume = MainMenu.volumeScale;
            }
            if (audioSources.Length >= 5)
            {
                audioSources[4].volume = MainMenu.volumeScale;
            }

            hasRedScreenFinished = false;
            isCopAttackOver = false;
            hasAnimStarted = false;
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            playerRotationX = transform.rotation.x;
            isPlayerHoldingBat = false;
            shouldPlayerLookBack = false;

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
                    bat = GameObject.Find("Baseball Bat");
                    GameObject.Find("Baseball Bat").GetComponent<Rigidbody>().useGravity = false;

                    break;
                case 9:
                    ObjectiveManager3D.SetObjectiveText("What have you done...");
                    canPlayerMove = false;
                    shouldPlayerLookBack = true;
                    bat = GameObject.Find("Baseball Bat");
                    GameObject.Find("Baseball Bat").GetComponent<Rigidbody>().useGravity = false;

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
                print("this is working");
                if (Input.GetKey(KeyCode.W) && transform.position.z <= 11.5)
                {
                    if (!audioSources[2].isPlaying) { audioSources[2].Play(); }
                    //audioSources[0].Play();
                    print("move forward");
                    //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
                    transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                }
                if (Input.GetKey(KeyCode.S) && transform.position.z >= -8.568307)
                {
                    if (!audioSources[2].isPlaying) { audioSources[2].Play(); }
                    print("move back");
                    //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
                    transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
                }
            }
            if (shouldPlayerLookBack)
            {
                GetComponent<Animator>().Play("3D Player");
                //audioSources[4].Play();
            }


            if (isPlayerHoldingBat)
            {
                ObjectiveManager3D.SetObjectiveText("Drop it.");
                if (Input.GetKeyDown(KeyCode.G))
                {
                    //print("Gravity is true");
                    print("before bat drop");
                    GameObject.Find("Baseball Bat").GetComponent<Rigidbody>().useGravity = true;
                    audioSources[3].Play();
                    print("after bat drop");
                    canPlayerMove = true;
                    print(canPlayerMove);
                    ObjectiveManager3D.SetObjectiveText("Get out of here.");
                    isPlayerHoldingBat = false;
                }
            }
            if (bat != null && bat.transform.position.y <= -5)
            {
                Destroy(bat);
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
                    //audioSources[0].Play();
                    ObjectiveManager3D.SetObjectiveText("They know.");
                    if (!isCopAttackOver && !audioSources[0].isPlaying) { audioSources[0].Play(); }
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
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayerFinishedTurning()
    {
        shouldPlayerLookBack = false;
        isPlayerHoldingBat = true;
        GameObject.Find("Player").GetComponent<Animator>().enabled = false;
    }

}
