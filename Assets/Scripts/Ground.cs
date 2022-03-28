using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] Transform ground1;
    [SerializeField] Transform ground2;
    [SerializeField] float xLimit;
    [SerializeField] float xOffset;
    float speed;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        speed = GameManager.Instance.GetSpeed();
        Player.gameOver += GameOver;
      

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameOver) return;
        ground1.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
        ground2.Translate(Vector2.left * speed * Time.deltaTime,Space.Self);

        if(ground1.position.x < xLimit)
        {
            ground1.localPosition = (Vector2)ground2.localPosition + Vector2.right * xOffset;
        }
        if (ground2.position.x < xLimit)
        {
            ground2.localPosition = (Vector2)ground1.localPosition + Vector2.right * xOffset;
        }
    }

    private void OnDisable()
    {
        Player.gameOver -= GameOver;
    }
    void GameOver()
    {
        gameOver = true;
    }
}
