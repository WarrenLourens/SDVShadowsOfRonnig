using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dialog : MonoBehaviour
{// Code copied from Jimmy Vegas(24 April 2019)How to display text from an input field using c# unity tutorial.Retrieved (26 August 2020) from https://www.youtube.com/watch?v=2liZtyMhIQQ
    public string PlayerInput;
    public GameObject InputField;
    public GameObject textDisplay;

    public void StoreInput()
    {
        PlayerInput =  InputField.GetComponent<Text>().text;
     //This is the switch statement that is used to determine which action needs to be taken based on the user's input. The ToLower fuction is called to convert input to lower case
            switch (PlayerInput.ToLower()) {
            case "search":
                textDisplay.GetComponent<Text>().text = "There is nothing of intrest at the momet. Need to be more specific.";
                break;
            case "search body":
                textDisplay.GetComponent<Text>().text = "You search the body.";
                break;
            case "open bags":
                SceneManager.LoadScene("Inventory");
                break;
            case "open map":
                SceneManager.LoadScene("Map");
                break;
            case "close map":
                SceneManager.LoadScene("Game");
                break;
            case "close bags":
                SceneManager.LoadScene("Game");
                break;
        }

    }

        

}
