﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Camera mainCam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
