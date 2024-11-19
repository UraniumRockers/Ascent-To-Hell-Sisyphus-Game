using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveManager2DAndBossfight : MonoBehaviour
{
    private static TMP_Text objectiveText;
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Defining variables
        objectiveText = GameObject.Find("2D/Bossfight Objectives").GetComponent<TMP_Text>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        #region Setting Original Objective Texts
        switch (sceneIndex)
        {
            // Origin Levels
            case 1:
            case 4:
            case 7:
                Change2DObjectiveText("Explore.");
                break;

            // Minigames
            case 2:
            case 5:
            case 10:
                Change2DObjectiveText("Climb the mountain.");
                break;

            // Story 1
            case 3:
                Change2DObjectiveText("Get out of here.");
                break;

            // Story 2
            case 6:
                Change2DObjectiveText("Drop it.");
                break;
            // Story 3
            case 11:
                Change2DObjectiveText("What have you done...");
                break;
            // Bossfight
            case 8:
                Change2DObjectiveText("Persevere.");
                break;
                #endregion
        }
    }

    #region Function to Set Objective
    public static void Change2DObjectiveText(string text)
    {
        ObjectiveManager2DAndBossfight.objectiveText.text = $"Objective: {text}";
    }
    #endregion
}
