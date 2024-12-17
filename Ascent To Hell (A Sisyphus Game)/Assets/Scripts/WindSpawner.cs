using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindSpawner : MonoBehaviour
{
    public static int windCount = 0;

    //private GameObject[] sprites = new GameObject[3];
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject windPrefab;
    private int sceneIndex;
    private int maxWindCount;
    private GameObject windObstacle;
    private Vector2[,] spawnPoints = { { new Vector2(-10.5f, 1.7f), new Vector2(-10.5f, -.78f), new Vector2(-10.5f, -3.64f) }, { new Vector2(10.5f, 1.7f), new Vector2(10.5f, -.78f), new Vector2(10.5f, -3.64f) } };

    // Start is called before the first frame update
    void Start()
    {
        windCount = 0;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 2:
                maxWindCount = 1;
                break;
            case 8:
                maxWindCount = 2;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (windCount == 0 && gameObject.name == "Wind Spawner" && !PlayerGame2D.didPlayerFail && !PlayerGame2D.didPlayerWin)
        {
            if (sceneIndex == 5)
            {
                maxWindCount = Random.Range(1, 3);
            }

            for (int i = 0; i < maxWindCount; i++)
            {
                int firstIndex = Random.Range(0, 2);
                int secondIndex = Random.Range(0, 3);
                //print($"First Index: {firstIndex}");
                //print($"Second Index: {secondIndex}");
                Quaternion rotation = (firstIndex == 1) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
                //print($"Spawn Position: {spawnPoints[firstIndex, secondIndex]}");
                windObstacle = Instantiate(windPrefab, spawnPoints[firstIndex, secondIndex], rotation);
                windObstacle.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];

                windCount++;
                //print("Wind was spawned");

            }

        }

    }
}
