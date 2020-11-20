using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestJsnDropNetworkService : MonoBehaviour
{
    public void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public void jsnListReceiverDel(List<Player> pReceivedList)
    {
        Debug.Log("Received items " + pReceivedList.Count());
        foreach (Player lcReceived in pReceivedList)
        {
            Debug.Log("Received {" + lcReceived.PlayerID + "," + lcReceived.Password + "," + lcReceived.HiScore.ToString()+"}");
        }// for

        // To do: produce an appropriate response
    }
    // Start is called before the first frame update
    void Start()
    {
        #region Test jsn drop
        JSONDropService jsDrop = new JSONDropService { Token = "06d8e924-e61e-4b1f-ae2b-8575a0cdf85c" };


        // Create table person
        jsDrop.Create<Person, JsnReceiver>(new Person
        {
            Name = "UUUUUUUUUUU",// give the call an example of the data it needs to store
            Score = 0,
            Password = "***************************"
        }, jsnReceiverDel); //@@@@@@@@@@@@@@@@@@@@@@@@@@ THIS IS THE CORRECT SCRIPT@@@@@@@@@@@@@@@@@@@@
        /*
        // Store people records
        jsDrop.Store<tblPerson,JsnReceiver> (new List<tblPerson>
        {
            new tblPerson{PersonID = "Jack",HighScore = 100,Password ="test"},
            new tblPerson{PersonID = "Jonny",HighScore = 200,Password ="test1"},
            new tblPerson{ PersonID = "Jill",HighScore = 300,Password ="test2"}
         }, jsnReceiverDel);
        
        // Retreive all people records
        jsDrop.All<tblPerson, JsnReceiver>(jsnListReceiverDel, jsnReceiverDel);
        
        jsDrop.Select<tblPerson,JsnReceiver>("HighScore > 200",jsnListReceiverDel, jsnReceiverDel);
        
        jsDrop.Delete<tblPerson, JsnReceiver>("PersonID = 'Jonny'", jsnReceiverDel);
        
        jsDrop.Drop<tblPerson, JsnReceiver>(jsnReceiverDel);
        */
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

