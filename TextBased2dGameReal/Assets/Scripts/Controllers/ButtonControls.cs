using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControls : MonoBehaviour
{// Code has been copied from Rabidgremlin(25 January 2016) A better bunny death and scoring[RNDBITS-009][RBR07] Retrieved 26 August 2020 from https://www.youtube.com/watch?v=6aPYA3ZcB4I&list=PLvUqRm2B9RRBgJipfDmFR7sFhEwBn7aGT&index=7
 //Load new scene
    public void BackButton()
    {
        SceneManager.LoadScene("Game");
    }
}
