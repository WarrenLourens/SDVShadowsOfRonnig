using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPlayer : MonoBehaviour
{
    public static SingletonPlayer instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
