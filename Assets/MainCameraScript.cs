﻿using System.Collections;
using Domini;
using Domini.Buildings;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private GameManager _gameManager;
    
    // Use this for initialization
    void Start()
    {
        print("Start");
        _gameManager = GameManager.Instance;
        _gameManager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _gameManager.Update(Time.time, Time.deltaTime);
        if (Input.GetMouseButtonUp(0))
        {
            print("Clicked");
            _gameManager.BuildingManager.Build(BuildingType.Woodjack);
        }
    }
}