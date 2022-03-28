using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float incSpeed;
    [SerializeField] float speedIncInterval;
    float time;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        speed = GameManager.Instance.GetSpeed();
        Player.gameOver += GameOver;
    }

    private void OnDisable()
    {
        Player.gameOver -= GameOver;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameOver) return;
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);

        time += Time.deltaTime;
        if(time >= speedIncInterval)
        {
            IncSpeed();
        }
    }

    void IncSpeed()
    {
        speed += incSpeed;
        time = 0;
    }

    void GameOver()
    {
        gameOver = true;
    }
}
