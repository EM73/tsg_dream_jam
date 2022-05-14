using System;
using System.Collections.Generic;
using System.Linq;
using MiscUtil.Xml.Linq.Extensions;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Action returnObject;
    [SerializeField]
    private Vector3 speed= Vector3.down;

    [SerializeField] private List<ObstacleTypeContainer> types;

    private ObstacleType type;

    private void Update()
    {
        if(GameManager.get.isGame)
            transform.position += speed * Time.deltaTime;
        
        if(transform.position.magnitude > 50)
            returnObject?.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (type)
        {
            case ObstacleType.Death:
                GameManager.get.isGame = false;
                break;
            case ObstacleType.Invincible:
                GameManager.get.isGame = false;
                break;
            case ObstacleType.Points:
                GameManager.get.isGame = false;
                break;
            case ObstacleType.Shuffle:
                GameManager.get.isGame = false;
                break;
            case ObstacleType.Vision:
                GameManager.get.isGame = false;
                break;
        }
        //returnObject?.Invoke();
    }

    public void SetUp(ObstacleType type)
    {
        types.ForEach(x=>x.gameObject.SetActive(false));
        types.FirstOrDefault(x=>x.type == type).gameObject.SetActive(true);
    }

    [Serializable]
    internal class ObstacleTypeContainer
    {
        public ObstacleType type;
        public GameObject gameObject;
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
