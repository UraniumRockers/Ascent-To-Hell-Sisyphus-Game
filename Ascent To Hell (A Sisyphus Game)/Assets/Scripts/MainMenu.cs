using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static float volumeScale;

    private GameObject mainMenuButtons;
    private GameObject settingsStuff;
    private Slider slider;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuButtons = GameObject.Find("Main Buttons");
        settingsStuff = GameObject.Find("Settings Stuff");

        volumeScale = 0.5f;
        slider = GameObject.Find("Volume Slider").GetComponent<Slider>();
        slider.value = volumeScale;

        settingsStuff.SetActive(false);

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = volumeScale * .25f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        volumeScale = slider.value;
        audioSource.volume = volumeScale * .25f;

        if (!audioSource.isPlaying) { audioSource.Play(); }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSettings()
    {
        mainMenuButtons.SetActive(false);
        settingsStuff.SetActive(true);
    }

    public void HideSettings()
    {
        mainMenuButtons.SetActive(true);
        settingsStuff.SetActive(false);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
