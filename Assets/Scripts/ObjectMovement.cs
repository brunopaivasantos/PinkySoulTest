using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float incSpeed;
    [SerializeField] float speedIncInterval;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.Instance.GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
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
}
