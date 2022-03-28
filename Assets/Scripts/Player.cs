using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static event UnityAction gameOver;
    [SerializeField] HUD hud;
    [SerializeField] float jumpForce;
    int coins;
    int jumps;
    Rigidbody2D rb;
    bool jumping;
    int lifes;
    bool invencible;
    bool isDead;
    SpriteRenderer spriteRenderer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        lifes = GameManager.Instance.GetHP(); ;
        coins = GameManager.Instance.GetCoins();
        jumps = GameManager.Instance.GetJumps();
        hud.UpdateTotalLife(lifes);
        hud.UpdateCoins(coins);
        hud.UpdateJumps(jumps);
        rb = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            if (jumps > 0)
                Jump();
            else
                hud.NoJumpAnimation();
        }
    }

    void Jump()
    {
        anim.SetBool("Jump", true);
        SoundManager.Instance.Play(AudioTypes.SFX_Jump);
        jumps--;
        hud.UpdateJumps(jumps);
        jumping = true;
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coins++;
            hud.UpdateCoins(coins);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = false;
            anim.SetBool("Jump", false);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            if (!invencible)
                TakeHit();
        }
    }

    void TakeHit()
    {
        lifes--;
        hud.DecreaseLife(lifes);
        if (lifes == 0)
        {
            anim.SetTrigger("Die");
            gameOver?.Invoke();
            isDead = true;
        }
        else StartCoroutine(Invencible());
    }

    public void GameOver()
    {
        GameManager.Instance.GameOver(coins);
    }
    IEnumerator Invencible()
    {
        invencible = true;
        float time = 0;
        float blinkTime = .15f;

        while (time < 3)
        {
            time += Time.deltaTime;
            blinkTime -= Time.deltaTime;

            if (blinkTime <= 0)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                blinkTime = .15f;
            }
            yield return null;


        }
        spriteRenderer.enabled = true;
        invencible = false;
    }
}
