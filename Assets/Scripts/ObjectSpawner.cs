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

    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        SetCoinInterval();
        SetObstacleInterval();
        Player.gameOver += GameOver;
    }
    private void OnDisable()
    {
        Player.gameOver -= GameOver;
    }
    void GameOver()
    {
        gameOver = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;
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
