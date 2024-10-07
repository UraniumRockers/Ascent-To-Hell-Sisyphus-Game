using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    [SerializeField] Transform player2D;

    // Update is called once per frame
    void Update()
    {
        transform.position = player2D.position + Vector3.forward * -10;
    }
}
