using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;
// Code adknowlegement: Blackthornprod(9 April 2018) Cool Dialog system- easy unity and c# tutorial. Recieved from Youtube https://www.youtube.com/watch?v=f-oSXg6_AMQ
public class TitleAutoRun : MonoBehaviour
{
    public Text Intro;// Selects the textbox to populate
    public string[] sentences; // An array to hold all the sentences for the storyline.
    private int index; 
    public float typingSpeed;// Determines how fast each letter takes to appear on screen.
    public GameObject continueButton;
    

    private void Start()
    {
        
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (Intro.text == sentences[index])// Checks to see if the sentence is finished being displayed if so then the continue button will be displayed
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) // the foreach loop to display each character of a sentence.
        {
            Intro.text += letter; // Adds one letter to the sentence
            yield return new WaitForSeconds(typingSpeed); // Yield the return delays the action
        }

    }

    public void NextSentence()
    {
       
        continueButton.SetActive(false); // Hides the button
        if (index < sentences.Length - 1)
        {
            index++; 
            Intro.text = " ";
            StartCoroutine(Type());
        }
        else
        {
            Intro.text = "";
            continueButton.SetActive(false); // Hides the continue button
        }
    }

    
}
