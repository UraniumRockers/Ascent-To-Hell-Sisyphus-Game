using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel2D : MonoBehaviour
{
    [SerializeField] float speed;                                         // Movement speed
    private int sceneIndex;                                               // Scene Index
    private List<string> thoughtBarText = new List<string>();             // List of stuff to say in timed text

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; // Get scene index

        // MAKE THESE ARGUMENTS ARRAYS BY MAKING A VARIABLE IN THE BEGINNGING AND SETTING IT TO THAT
        #region Initial Timed Text (2D)
        switch (sceneIndex)
        {
            case 1:
                thoughtBarText.Add("Where... am I? What is this place?");
                thoughtBarText.Add("There's literally nothing here. Except for that tablet...");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                break;
            case 4:
                thoughtBarText.Add("Here again? And what the hell was that? Is this a dream or something?");
                thoughtBarText.Add("If it is, this is messed up. I just saw myself get frickin killed...");
                thoughtBarText.Add("Do I have to do all of that stuff again?");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                break;
            case 7:
                thoughtBarText.Add("...I remember that bat... why was I holding it? What would I have done with it in an alleyway...");
                thoughtBarText.Add("And am I in a loop or some crap? I really don't wanna do all that again...");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                break;
            case 9:
                thoughtBarText.Add("Okay. What the hell. Was that... me? Did I fight myself?");
                thoughtBarText.Add("And what was... I?... talking about? What crime? Is that related to the bat?");
                thoughtBarText.Add("I hope I wake up from whatever this is soon...");
                ThoughtCanvasManager2D.SetThoughtBarText(thoughtBarText);
                break;
        }
        #endregion
    }


    void Update()
    {
        #region Movement
        if (Tablet.shouldPlayerMove && ThoughtCanvasManager2D.shouldPlayerMove)
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
    }
}
