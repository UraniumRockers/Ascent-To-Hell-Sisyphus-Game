using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager2DAndBossfight : MonoBehaviour
{
    public static float health;

    private static GameObject[] health2DAndBossfight = new GameObject[4];
    private int sceneIndex;

    #region Setting Vars & Initial Set Health
    private void Start()
    {
        health2DAndBossfight[0] = GameObject.Find("-.5");
        health2DAndBossfight[1] = GameObject.Find("-1.5");
        health2DAndBossfight[2] = GameObject.Find("-2.5");
        health2DAndBossfight[3] = GameObject.Find("-3.5");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        switch (sceneIndex)
        {
            case 1:
            case 4:
            case 7:
                Set_5Hearts();
                break;
            case 2:
                Set1_5Hearts();
                break;
            case 5:
                Set2_5Hearts();
                break;
            case 8:
                Set3_5Hearts();
                break;
        }
        //if (sceneIndex == 1 || sceneIndex == 4 || sceneIndex == 7)
        //{
        //    Set_5Hearts();
        //}
        
    }
    #endregion
    #region Setting Health Functions
    public static void DetermineSetHearts(float targetHealth)
    {
        switch (Mathf.Abs(targetHealth))
        {
            case .5f:
                Set_5Hearts();
                break;
            case 1.5f:
                Set1_5Hearts();
                break;
            case 2.5f:
                Set2_5Hearts();
                break;
            case 3.5f:
                Set3_5Hearts();
                break;
        }
    }

    public static void Set_5Hearts()
    {
        HealthManager2DAndBossfight.health = -.5f;
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
        HealthManager2DAndBossfight.health = -1.5f;
        // Activating -1.5
        health2DAndBossfight[1].SetActive(true);

        // Deactivating -.5, -2.5, & -3.5
        health2DAndBossfight[0].SetActive(false);
        health2DAndBossfight[2].SetActive(false);
        health2DAndBossfight[3].SetActive(false);
    }

    public static void Set2_5Hearts()
    {
        HealthManager2DAndBossfight.health = -2.5f;
        // Activating -2.5
        print($"Was -2.5 null? {health2DAndBossfight[2] == null}");
        //GameObject.Find("-2.5").SetActive(true);

        health2DAndBossfight[2].SetActive(true);

        // Deactivating -.5, -1.5, & -3.5
        health2DAndBossfight[0].SetActive(false);
        health2DAndBossfight[1].SetActive(false);
        health2DAndBossfight[3].SetActive(false);
    }

    public static void Set3_5Hearts()
    {
        HealthManager2DAndBossfight.health = -3.5f;
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