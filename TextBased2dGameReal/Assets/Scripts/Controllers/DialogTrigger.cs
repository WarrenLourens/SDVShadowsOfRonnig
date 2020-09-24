using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogTrigger : MonoBehaviour
    //Code copied from Code Monkey(18 Dec, 2019) Collisions and Triggers("OnTriggerEnter not working!") retrieved 31 August 2020 from https://www.youtube.com/watch?v=Bc9lmHjqLZc
{
    public GameObject UiObject;
    public GameObject Trigger;
    // This ensures that the icon above the characte's head is not visiable when the game start.
    void Start()
    {
        UiObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UiObject.SetActive(true);
    }
    // Upon exiting the ontrigger collider the icon above the character's head will dissapear
    private void OnTriggerExit2D(Collider2D collision)
    {
        UiObject.SetActive(false);
    }
}
