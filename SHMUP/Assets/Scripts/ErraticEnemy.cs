using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErraticEnemy : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private float directionChangeTime = 3f;
    private float velocity = 2f;
    private Vector2 direction;
    private Vector2 movementPerSecond;

    void calcuateNewMovementVector()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0)).normalized;
        movementPerSecond = direction * velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
            transform.position.y + (movementPerSecond.y * Time.deltaTime));

        if (direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }
    }
}
