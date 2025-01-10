using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStory3D : MonoBehaviour
{
    public static bool canPlayerMove;

    private static bool isCopAttackOver = false;

    [SerializeField] private float speed;
    [SerializeField] private Animation copAttack;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        isCopAttackOver = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        switch (sceneIndex)
        {
            case 3:
                ObjectiveManager3D.SetObjectiveText("Get out of here.");
                canPlayerMove = true;
                break;
            case 6:
                ObjectiveManager3D.SetObjectiveText("Drop it.");
                canPlayerMove = true;
                break;
            case 9:
                ObjectiveManager3D.SetObjectiveText("What have you done...");
                canPlayerMove = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayerMove)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.z <= 11.5)
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S) && transform.position.z >= -11)
            {
                transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
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
            }
            if (isCopAttackOver)
            {
                print("done");
            }
        }
    }

    public void CopAttackOver()
    {
        isCopAttackOver = true;
    }
}
