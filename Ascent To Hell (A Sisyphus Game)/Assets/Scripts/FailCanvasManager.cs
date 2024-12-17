using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailCanvasManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        gameObject.GetComponent<Canvas>().sortingOrder = 6;
    }
    public void RestartMinigame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        print("abanana");
    }
}
