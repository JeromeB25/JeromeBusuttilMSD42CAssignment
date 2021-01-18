﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreDisplay : MonoBehaviour
{
    Text scoretext;
    GameSession gameSession; 
    
    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>(); 
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = gameSession.getscore().ToString(); 
    }
}
