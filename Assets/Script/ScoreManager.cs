using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;
    
    public static int score;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        UpdateScore();      
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
