using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] float minIntervalObstacle;
    [SerializeField] float maxIntervalObstacle;
    [SerializeField] float minIntervalCoin;
    [SerializeField] float maxIntervalCoin;

    [SerializeField] Transform coinPoint;
    [SerializeField] Transform obstaclePoint;

    float timeCoin;
    float coinInterval;
    float timeObstacle;
    float obstacleInterval;
    // Start is called before the first frame update
    void Start()
    {
        SetCoinInterval();
        SetObstacleInterval();
    }

    // Update is called once per frame
    void Update()
    {
        timeCoin += Time.deltaTime;
        timeObstacle += Time.deltaTime;

        if (timeCoin > coinInterval)
        {
            Instantiate(coinPrefab, coinPoint.position, Quaternion.identity);
            SetCoinInterval();
        }

        if (timeObstacle > obstacleInterval)
        {
            Instantiate(obstaclePrefab, obstaclePoint.position, Quaternion.identity);
            SetObstacleInterval();
        }
    }

    void SetObstacleInterval()
    {
        timeObstacle = 0;
        obstacleInterval = Random.Range(minIntervalObstacle, maxIntervalObstacle);
    }

    void SetCoinInterval()
    {
        timeCoin = 0;
        coinInterval = Random.Range(minIntervalCoin, maxIntervalCoin);
    }

}
