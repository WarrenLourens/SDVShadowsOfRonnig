﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBackground : MonoBehaviour
{
    public static SingletonBackground instance;

    private void Awake()
    {
        if (instance == null)
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
