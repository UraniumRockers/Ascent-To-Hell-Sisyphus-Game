using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wind : MonoBehaviour
{
    //private GameObject[] sprites = new GameObject[3];
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private Vector2[,] spawnPoints = { { new Vector2(-10.5f, .5f), new Vector2(-10.5f, -1.21f), new Vector2(-10.5f, -3.64f) }, { new Vector2(10.5f, .5f), new Vector2(10.5f, -1.21f), new Vector2(10.5f, -3.64f), } };

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, 3)];

        //for (int i = 0; i < 3; i++)
        //{
        //    sprites[i] = transform.GetChild(i).gameObject;
        //    sprites[i].SetActive(false);
        //    //print(sprites[i].name);
        //}
        //int randSprite = Random.Range(0, 3);
        //sprites[randSprite].SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
