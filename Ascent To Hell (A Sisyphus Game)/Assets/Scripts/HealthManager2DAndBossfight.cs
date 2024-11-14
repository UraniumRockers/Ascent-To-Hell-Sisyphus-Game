using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager2DAndBossfight : MonoBehaviour
{
    private static GameObject[] health2DAndBossfight = new GameObject[4];
    private int sceneIndex;

    #region Setting Vars & Initial Set Health
    private void Awake()
    {
        health2DAndBossfight[0] = GameObject.Find("-.5");
        health2DAndBossfight[1] = GameObject.Find("-1.5");
        health2DAndBossfight[2] = GameObject.Find("-2.5");
        health2DAndBossfight[3] = GameObject.Find("-3.5");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 1 || sceneIndex == 4 || sceneIndex == 7)
        {
            Set_5Hearts();
        }
        else if (sceneIndex == 9)
        {
            Set3_5Hearts();
        }
    }
    #endregion
    #region Setting Health Functions
    public static void Set_5Hearts()
    {
        // Activating -.5
        health2DAndBossfight[0].SetActive(true);

        // Deactivating -1.5, -2.5, & -3.5
        for (int i = 1; i < 4; i++)
        {
            health2DAndBossfight[i].SetActive(false);
        }
    }

    public static void Set1_5Hearts()
    {
        // Activating -1.5
        health2DAndBossfight[1].SetActive(true);

        // Deactivating -.5, -2.5, & -3.5
        health2DAndBossfight[0].SetActive(false);
        health2DAndBossfight[2].SetActive(false);
        health2DAndBossfight[3].SetActive(false);
    }

    public static void Set2_5Hearts()
    {
        // Activating -2.5
        health2DAndBossfight[2].SetActive(true);

        // Deactivating -.5, -1.5, & -3.5
        health2DAndBossfight[0].SetActive(false);
        health2DAndBossfight[1].SetActive(false);
        health2DAndBossfight[3].SetActive(false);
    }

    public static void Set3_5Hearts()
    {
        // Activating -3.5
        health2DAndBossfight[3].SetActive(true);
        
        // Deactivating -.5, -1.5, & -2.5
        for (int i = 0; i < 3; i++)
        {
            health2DAndBossfight[i].SetActive(false);
        }
    }
    #endregion

    // FOR TESTING ONLY
    #region Key Inputs to Test
    /*
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Set_5Hearts();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Set1_5Hearts();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Set2_5Hearts();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            Set3_5Hearts();
        }
    }
    */
    #endregion
}