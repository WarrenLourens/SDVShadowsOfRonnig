using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordRegController : MonoBehaviour
{
    public GameObject RegPanel;
    public GameObject PasspromptPanel;
    public InputField User_Name;
    public InputField Password;

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

    public void RegisterPlayer() // public  method called RegisterPlayer
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
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
