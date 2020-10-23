using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordRegController : MonoBehaviour
{
   public Text Score;
    public GameObject RegPanel;
    public GameObject PasspromptPanel;
    public InputField User_Name;
    public InputField Password;
   
    public void StartScore()
    {
        if (GameModel.currentPlayer != null) { 
           Score.text = GameModel.currentPlayer.HiScore.ToString();
        }
    }
    //public void UpdateScore()
    //{

    //    if (GameModel.currentPlayer != null)
    //    {
    //        int newScore = 0;
    //        newScore = Convert.ToInt32(Score.text) + 1;
    //        GameModel.currentPlayer.HiScore = newScore;
    //        GameModel.ds.storePlayer(GameModel.currentPlayer);
    //        Score.text = newScore.ToString();
    //    }
    //}

    private void HidePanels()
    {
        RegPanel.SetActive(false);
        PasspromptPanel.SetActive(false);
    }
    private void ShowRegPanel()
    {
        RegPanel.SetActive(true);
        PasspromptPanel.SetActive(false);
    }

    private void ShowPasspromptPanel()
    {
        RegPanel.SetActive(false);
        PasspromptPanel.SetActive(true);
    }

    public void TryAgain()
    {
        HidePanels();
    }
    public void CheckPassword()
    {

        HidePanels();
        switch (GameModel.CheckPassword(User_Name.text, Password.text))
        {
            case GameModel.PasswdMode.OK:
                HidePanels();
                SceneManager.LoadScene("Game");

                break;
            case GameModel.PasswdMode.NeedName:
                ShowRegPanel();
                break;
            case GameModel.PasswdMode.NeedPassword:
                ShowPasspromptPanel();
                break;

        }
        
    }
    // ##########################Test method
    //public void PlayerPosition() {
    //    GameModel.SavePlayer();
    //}


    public void RegisterPlayer() // public  method called RegisterPlayer accessable by unity game objects
    {
        GameModel.RegisterPlayer(User_Name.text, Password.text); // takes the input fields as parameters
        HidePanels(); // hides all the unneeded panel
        SceneManager.LoadScene("Game"); // loads the game scene
    }
    // Start is called before the first frame update
    void Start()
    {
        RegPanel.SetActive(false);// sets the registration panels to false on start
        PasspromptPanel.SetActive(false);
        StartScore();
        
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
