using System;
using System.Collections.Generic;
using System.Linq;
using MiscUtil.Xml.Linq.Extensions;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public Action returnObject;
    [SerializeField]
    private Vector3 speed= Vector3.down;

    [SerializeField] private List<ObstacleTypeContainer> types;

    [SerializeField] private AudioSource source;

    private ObstacleType type;

    private void Update()
    {
        if(GameManager.get.isGame)
            transform.position += speed * (Time.deltaTime * GameManager.get.speed);
        
        if(transform.position.magnitude > 50)
            returnObject?.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        var temo = types.FirstOrDefault(x => x.type == type).audioClip;
        if(temo != null)
            source.PlayOneShot(temo);
        switch (type)
        {
            case ObstacleType.Death:
                if (GameManager.get.invincible <= 0)
                {
                    GameManager.get.isGame = false;
                    GameManager.get._player.enabled = true;
                    GameManager.get._player.Play(); 
                }
                break;
            case ObstacleType.Invincible:
                GameManager.get.invincible = 6;
                break;
            case ObstacleType.Points:
                ScoreManager.get.AddScore(15);
                break;
            case ObstacleType.Shuffle:
                foreach (var obstacle in FindObjectsOfType<Obstacle>())
                {
                    obstacle.SetUp((ObstacleType)Random.Range(0,5));
                }
                break;
            case ObstacleType.Vision:
                GameManager.get.vision = 5;
                break;
        }
        //returnObject?.Invoke();
    }

    public void SetUp(ObstacleType type)
    {
        this.type = type;
        types.ForEach(x=>x.gameObject.SetActive(false));
        types.FirstOrDefault(x=>x.type == type).gameObject.SetActive(true);
    }

    [Serializable]
    internal class ObstacleTypeContainer
    {
        public ObstacleType type;
        public GameObject gameObject;
        public AudioClip audioClip;
    }

    public enum ObstacleType
    {
        Death,
        Vision,
        Shuffle,
        Invincible,
        Points
    }
}
