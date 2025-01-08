using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveManager3D : MonoBehaviour
{
    int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public static void SetObjectiveText(string objective)
    {
        GameObject.Find("3D Objectives").GetComponent<TMP_Text>().text = $"Objective: {objective}";
    }
}
