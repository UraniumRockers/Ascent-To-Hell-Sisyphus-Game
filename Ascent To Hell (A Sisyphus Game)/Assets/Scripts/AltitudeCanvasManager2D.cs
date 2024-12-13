using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class AltitudeCanvasManager2D : MonoBehaviour
{
    [SerializeField] private float waitTime = 0.5f;
    private TMP_Text altitudeText;
    private int altitude;
    private float initialTime;
    

    // Start is called before the first frame update
    void Start()
    {
        altitudeText = GetComponentInChildren<TMP_Text>();
        altitude = 0;
        initialTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - initialTime >= waitTime)
        {
            //print("Altitude Increase");
            altitudeText.text = $"Altitude: {altitude}m";
            altitude++;
            initialTime = Time.time;
        }
    }


}
