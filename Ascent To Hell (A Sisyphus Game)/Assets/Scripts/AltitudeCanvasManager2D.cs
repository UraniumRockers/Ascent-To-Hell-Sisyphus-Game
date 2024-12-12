using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class AltitudeCanvasManager2D : MonoBehaviour
{
    private TMP_Text altitudeText;
    private int altitude;

    // Start is called before the first frame update
    void Start()
    {
        altitudeText = GetComponentInChildren<TMP_Text>();
        altitude = 0;
    }

    private void FixedUpdate()
    {
        StartCoroutine(AltitudeIncrease());
    }

    IEnumerator AltitudeIncrease()
    {
        altitudeText.text = $"Altitude: {altitude}m";
        altitude++;
        yield return new WaitForSeconds(1);
        print("Increase alt");
    }


}
