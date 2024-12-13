using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wind : MonoBehaviour
{
    //private GameObject[] sprites = new GameObject[3];
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject windPrefab;
    private int windCount;
    private float windSpeed;
    private GameObject windObstacle;
    private Vector2[,] spawnPoints = { { new Vector2(-10.5f, 1.7f), new Vector2(-10.5f, -.78f), new Vector2(-10.5f, -3.64f) }, { new Vector2(10.5f, 1.7f), new Vector2(10.5f, -.78f), new Vector2(10.5f, -3.64f) } };

    // Start is called before the first frame update
    void Start()
    {
        windCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (windCount == 0 && gameObject.name == "Wind Spawner")
        {
            windSpeed = Random.Range(3, 6);
            int firstIndex = Random.Range(0, 2);
            int secondIndex = Random.Range(0, 3);
            print($"First Index: {firstIndex}");
            print($"Second Index: {secondIndex}");
            Quaternion rotation = (firstIndex == 1) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
            print($"Spawn Position: {spawnPoints[firstIndex, secondIndex]}");
            windObstacle = Instantiate(windPrefab, spawnPoints[firstIndex, secondIndex], rotation);
            windObstacle.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
            windCount++;
            //print("Wind was spawned");

        }
        
        if (windObstacle.transform.rotation.y == 180)
        {
            if (windObstacle.transform.position.x >= -10.85)
            {
                windObstacle.transform.position += windSpeed * Time.deltaTime * Vector3.left;
            }
            else
            {
                windCount--;
                Destroy(windObstacle);
                //print("Wind was destroyed");
            }
        }
        else
        {
            if (windObstacle.transform.position.x <= 10.85)
            {
                windObstacle.transform.position += windSpeed * Time.deltaTime * Vector3.right;
            }
            else
            {
                windCount--;
                //Destroy(windObstacle);
                print("Wind was destroyed");
            }
        }
    }
}
