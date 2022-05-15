using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Pooling<Obstacle> _pool;
    [SerializeField] private Obstacle _template;

    [SerializeField]
    private Vector2 corners;
    private float timer;
    [SerializeField] private float _toSpawn;
    
    
    
    void Start()
    {
        _pool = new Pooling<Obstacle>(_template);
    }
    
    private void Update()
    {
        if(!GameManager.get.isGame)
            return;
        
        if (timer <= 0)
        {
            timer = _toSpawn;
            var temp = _pool.GetObject();
            temp.gameObject.SetActive(true);
            temp.transform.position = new Vector3(Random.Range(corners.x, corners.y), transform.position.y,
                transform.position.z);
            temp.SetUp((Obstacle.ObstacleType)Random.Range(0,5));
            temp.returnObject = () =>
            {
                temp.gameObject.SetActive(false);
                _pool.Return(temp);
            };

        }
        else
        {
            timer -= Time.deltaTime * GameManager.get.speed;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(corners.x, transform.position.y, transform.position.z), Vector3.one);
        Gizmos.DrawCube(new Vector3(corners.y, transform.position.y, transform.position.z), Vector3.one);
    }
}