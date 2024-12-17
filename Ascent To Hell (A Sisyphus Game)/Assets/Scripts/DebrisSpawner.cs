using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebrisSpawner : MonoBehaviour
{
    public static int debrisCount = 0;

    [SerializeField] int countForTesting;

    //private GameObject[] sprites = new GameObject[3];
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject debrisPrefab;
    private int sceneIndex;
    [SerializeField] private int maxDebrisCount;
    private GameObject debrisObstacle;
    private float initialTime;
    

    // Start is called before the first frame update
    void Start()
    {
        debrisCount = 0;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 2:
                maxDebrisCount = 1;
                break;
            case 5:
                maxDebrisCount = 2;
                break;
            case 8:
                maxDebrisCount = 3;
                break;
        }
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerGame2D.didPlayerFail && !PlayerGame2D.didPlayerWin)
        {
            RandomTimeSpawn();
        }
        countForTesting = debrisCount;
    }


    private void RandomTimeSpawn()
    {
        float randTime = Random.Range(0.25f, 1);
        if (debrisCount < maxDebrisCount && Time.time - initialTime >= randTime)
        {
            //print("Fake coroutine ran");
            initialTime = Time.time;
            Quaternion rotation = Quaternion.Euler(new Vector3(Random.Range(0, 1) * 180, Random.Range(0, 1) * 180, Random.Range(0, 361)));
            debrisObstacle = Instantiate(debrisPrefab, transform.position, rotation);
            debrisObstacle.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
            debrisCount++;
        }
    }
}
