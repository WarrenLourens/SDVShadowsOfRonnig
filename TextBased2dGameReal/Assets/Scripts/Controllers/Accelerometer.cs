﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accelerometer : MonoBehaviour
{
    

    private void Update()
    {
       
        if (Input.acceleration.sqrMagnitude >= 5f)
        {
            SceneManager.LoadScene("Login");
        }
    }
}
