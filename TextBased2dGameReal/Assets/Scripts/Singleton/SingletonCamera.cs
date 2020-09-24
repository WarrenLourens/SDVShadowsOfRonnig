using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCamera : MonoBehaviour
{//A singleton that is attached to the camera so that it does not get distroyed when changing scences
    public static  SingletonCamera instance;
    //The code is placed in an awake function because we need to check to see if there is another singleton game object present. Awake functions are called before start functions.
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
