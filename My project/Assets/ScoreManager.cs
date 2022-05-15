using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;
    [SerializeField] private TextMeshProUGUI scoreText;
    public static ScoreManager get { get; set; }

    private void Start()
    {
        get = this;
    }

    public void AddScore(int s)
    {
        score += s;
        scoreText.text = "Points: " + (int) score;
    }
    
    public void Update()
    {
        if (GameManager.get.isGame)
        {
            score += Time.deltaTime;
            scoreText.text = "Points: " + (int) score;
        }
        
    }
}
