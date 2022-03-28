using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float incSpeed;
    [SerializeField] float speedIncInterval;
    [SerializeField] GameObject particle;

    float time;
    bool gameOver;
    bool goingToHud;
    Vector2 coinHud;

    float limitX;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        speed = GameManager.Instance.GetSpeed();
        Player.gameOver += GameOver;
        GetLimitX();
    }

    private void OnDisable()
    {
        Player.gameOver -= GameOver;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameOver) return;

        if(goingToHud)
        {
            this.transform.position = Vector2.MoveTowards(transform.position,coinHud, 30 * Time.deltaTime);

            if(Vector2.Distance(transform.position, coinHud) < .05f)
            {
                Destroy(this.gameObject);
            }
            return;
        }

        this.transform.Translate(Vector2.left * speed * Time.deltaTime);

        time += Time.deltaTime;
        if(time >= speedIncInterval)
        {
            IncSpeed();
        }

        if(transform.position.x <  limitX)
        {
            Destroy(this.gameObject);
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

    public void GoToHud(HUD hud)
    {
        goingToHud = true;
        GameObject particles = Instantiate(particle, this.transform.position, this.transform.rotation);
        Destroy(particles, 2f);

        coinHud = hud.GetCoinImagePoisition();
        this.GetComponent<Collider2D>().enabled = false;

    }

    void GetLimitX()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        pos.x -= 10;

        limitX = pos.x;
    }
}
