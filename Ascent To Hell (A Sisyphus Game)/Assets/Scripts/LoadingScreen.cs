using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private static Image image;
    private static Color color;
    private static int i = 0;
    private static GameObject canvases;
    private static float elapsedTime;
    private static float oldTime;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        oldTime = 0;
        

        canvases = GameObject.Find("Canvases");        
        image = GetComponentInChildren<Image>();
        color = image.color;
        color.a = 0;
        i = 0;
    }


    public static void LoadScreen()
    {
        if (i == 0)
        {
            oldTime = Time.time;
            canvases.SetActive(false);
        }
        elapsedTime = Time.time - oldTime;
        print(elapsedTime.ToString());
        print($"i: {i}");
        if (i < 255)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, i * Time.deltaTime);
            print("This did something");
        }
        i++;

        if (elapsedTime > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
