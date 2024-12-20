using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel2D : MonoBehaviour
{
    public static bool isPlayerPrepared = false;                          // Is player ready to move on to boulder area?

    [SerializeField] private float speed;                                 // Movement speed
    private int sceneIndex;                                               // Scene Index
    private List<string> thoughtBarText = new();                          // List of stuff to say in timed text
    private bool canPlayerThinkBoutPressurePlate = true;                  // I ain't commenting this one 
    private bool hasPlayerInitiallyThought = false;

    private void Start()
    {
        hasPlayerInitiallyThought = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex; // Get scene index
        // MAKE THESE ARGUMENTS ARRAYS BY MAKING A VARIABLE IN THE BEGINNGING AND SETTING IT TO THAT
        #region Initial Timed Text (2D)
        switch (sceneIndex)
        {
            case 1:
                thoughtBarText.Add("Where... am I? What is this place?");
                thoughtBarText.Add("There's literally nothing here. Except for that tablet...");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                hasPlayerInitiallyThought = true;
                break;
            case 4:
                thoughtBarText.Add("Here again? And what the hell was that? Is this a nightmare or something?");
                thoughtBarText.Add("I hate this. Anyways...");
                thoughtBarText.Add("Do I have to do all of that stuff again? *sigh*");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                hasPlayerInitiallyThought = true;
                break;
            /*case 7:
                thoughtBarText.Add("...I remember that bat... why was I holding it? What would I have done with it in an alleyway...");
                thoughtBarText.Add("And am I in a loop or some crap? I really don't wanna do all that again.");
                thoughtBarText.Add("I hope I wake up from whatever this is soon...");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                hasPlayerInitiallyThought = true;
                break;*/
        }
        #endregion
    }


    void Update()
    {
        #region might fix bug with level 3 thought text
        if (sceneIndex == 7 && !hasPlayerInitiallyThought)
        {
            thoughtBarText.Add("...I remember that bat... why was I holding it? What would I have done with it in an alleyway...");
            thoughtBarText.Add("And am I in a loop or some crap? I really don't wanna do all that again.");
            thoughtBarText.Add("I hope I wake up from whatever this is soon...");
            ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
            hasPlayerInitiallyThought = true;
        }
        #endregion

        #region Movement
        if (LevelBoulder.canPlayerMove && ThoughtCanvasManager2D.canPlayerMove && PressurePlate.canPlayerMove && Tablet.canPlayerMove && Lock.canPlayerMove && DoorRotationScript.canPlayerMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += speed * Time.deltaTime * new Vector3(1, 1, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * -45), 200f);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.position += speed * Time.deltaTime * new Vector3(-1, 1, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 45), 200f);
                }
                else
                {
                    transform.position += speed * Time.deltaTime * Vector3.up;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.zero), 200f);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += speed * Time.deltaTime * new Vector3(1, -1, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * -135), 200f);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.position += speed * Time.deltaTime * new Vector3(-1, -1, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 135), 200f);
                }
                else
                {
                    transform.position += speed * Time.deltaTime * Vector3.down;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 180), 200f);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += speed * Time.deltaTime * Vector3.right;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * -90), 200f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += speed * Time.deltaTime * Vector3.left;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * 90), 200f);
            }
        }
        #endregion

        #region Boulder Area Text
        // Checks to see if player is up and not ready to be up
        if (transform.position.x >= -9.13 && transform.position.x <= 9.13 && transform.position.y >= 8.5)
        {
            if (!isPlayerPrepared)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);

                thoughtBarText.Clear();
                // Sets thinking text
                switch (sceneIndex)
                {
                    case 1:
                        thoughtBarText.Add("I have no clue what this place is, but I don't like it.");
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                        break;
                    case 4:
                        thoughtBarText.Add("I'm definitely not ready for this yet.");
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                        break;
                    case 7:
                        thoughtBarText.Add("...Where's the pressure plate?");
                        ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                        break;
                }
            }
            else
            {
                if (canPlayerThinkBoutPressurePlate)
                {
                    thoughtBarText.Clear();
                    switch (sceneIndex)
                    {
                        case 1:
                            thoughtBarText.Add("So... I guess I just step on that pressure plate?");
                            thoughtBarText.Add("Hopefully whatever happens isn't too bad.");
                            ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                            canPlayerThinkBoutPressurePlate = false;
                            break;
                        case 4:
                            thoughtBarText.Add("Here we go again.");
                            ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                            canPlayerThinkBoutPressurePlate = false;
                            break;
                        case 7:
                            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
                            thoughtBarText.Add("Am I in the right place?");
                            thoughtBarText.Add("This place is too empty...");


                            ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                            ObjectiveManager2DAndBossfight.Change2DObjectiveText("Find pressure plate.");
                            GameObject redCloudRight = GameObject.Find("Red Cloud (Right)");
                            print($"Is red cloud visible? {redCloudRight.GetComponent<SpriteRenderer>().enabled}");
                            if (!redCloudRight.GetComponent<SpriteRenderer>().enabled)
                            {
                                redCloudRight.GetComponents<BoxCollider2D>()[0].enabled = false;
                                redCloudRight.GetComponents<BoxCollider2D>()[1].enabled = true;
                                redCloudRight.GetComponent<SpriteRenderer>().enabled = true;
                                print("Cloud active and stuff");
                            }
                            canPlayerThinkBoutPressurePlate = false;
                            break;
                    }

                }
            }
       
        }
        #endregion
    }
}
