using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStory3D : MonoBehaviour
{
    public static bool canPlayerMove;

    [SerializeField] private float speed;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            }
        }

        if (transform.position.z >= 11.5)
        {
           // Do the policeman jumpscare
           // Sigma
        }
    }
}
