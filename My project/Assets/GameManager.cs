using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager get;
    public bool isGame = true;
    public float invincible;
    public float speed = 1;
    public float vision;

    [SerializeField] public VideoPlayer _player;
    
    [SerializeField]
    private List<MonoBehaviour> visionEffects;
    [SerializeField]
    private List<GameObject> invincibleEffects;

    private void Awake()
    {
        get = this;
    }

    private void Update()
    {
        if(invincible>0)
            invincible -= Time.deltaTime;
        
        if(vision>0)
            vision -= Time.deltaTime;
        if (isGame)
            speed += Time.deltaTime * 0.05f;
        
        if(vision>0)
            visionEffects.ForEach(x=>x.enabled = true);
        else
            visionEffects.ForEach(x=>x.enabled = false);
        
        
        if(invincible>0)
            invincibleEffects.ForEach(x=>x.SetActive(true));
        else
            invincibleEffects.ForEach(x=>x.SetActive(false));

        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene(0);
    }
}
