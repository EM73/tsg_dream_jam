using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;
    [SerializeField] private TextMeshProUGUI scoreText;
    public void Update()
    {
        if (GameManager.get.isGame)
        {
            score += Time.deltaTime;
            scoreText.text = ((int) score).ToString();
        }
        
    }
}
