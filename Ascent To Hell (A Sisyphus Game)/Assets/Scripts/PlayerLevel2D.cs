using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel2D : MonoBehaviour
{
    [SerializeField] float speed;
    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; // Get scene index

        // MAKE THESE ARGUMENTS ARRAYS BY MAKING A VARIABLE IN THE BEGINNGING AND SETTING IT TO THAT
        #region Initial Timed Text
        switch (sceneIndex)
        {
            case 1:
                ThoughtCanvasManager2D.SetThoughtBarText({ "Where... am I? What is this place?", "There's literally nothing here. Execpt for that tablet..." }, true);
                ThoughtCanvasManager2D.SetThoughtBarText("There's literally nothing here. Execpt for that tablet...", false);
                break;
            case 4:
                ThoughtCanvasManager2D.SetThoughtBarText("Here again? And what the hell was that? Is this a dream or something?", true);
                ThoughtCanvasManager2D.SetThoughtBarText("If it is, this is messed up. I just say myself get frickin killed...", false);
                ThoughtCanvasManager2D.SetThoughtBarText("Do I have to do all of that stuff again?", false);
                break;
            case 7:
                ThoughtCanvasManager2D.SetThoughtBarText("...I remember that bat... why was I holding it? What would I have done with it in an alleyway...", true);
                ThoughtCanvasManager2D.SetThoughtBarText("And am I in a loop or some crap? I really don't wanna do all that again...", false);
                break;
            case 9:
                ThoughtCanvasManager2D.SetThoughtBarText("Okay. What the hell. Was that... me? Did I fight myself?", true);
                ThoughtCanvasManager2D.SetThoughtBarText("I hope I wake up from whatever this is soon...", false);
                break;
            case 11:
                ThoughtCanvasManager2D.SetThoughtBarText("Did I do that...?", true);
                ThoughtCanvasManager2D.SetThoughtBarText("Did I... kill someone?", false);
                ThoughtCanvasManager2D.SetThoughtBarText("...", false);
                ThoughtCanvasManager2D.SetThoughtBarText("What... Why...", false);
                break;
        
        #endregion
    }


    void Update()
    {
        #region Movement
        if (Tablet.shouldPlayerMove || ThoughtCanvasManager2D.shouldPlayerMove)
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
