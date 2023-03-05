using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public CollisionManager collisionManager;
    private Vector3 enemyPosition = new Vector3(0, 0, 0);
    private float latestDirectionChangeTime;
    private float directionChangeTime = 3f;
    private float latestBulletShotTime;
    private float bulletShotTime = 0.5f;
    private float velocity = 2f;
    private Vector2 direction;
    private Vector2 movementPerSecond;
    private Camera cam;
    private float height;
    private float width;

    void calcuateNewMovementVector()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 0)).normalized;
        movementPerSecond = direction * velocity;
        collisionManager = FindObjectOfType<CollisionManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

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
        enemyPosition = transform.position;

        if (direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }

        if (Time.time - latestBulletShotTime > bulletShotTime)
        {
            latestBulletShotTime = Time.time;
            collisionManager.collidableObjects.Add(Instantiate(bullet, transform.position, transform.rotation).GetComponent<CollidableObject>());
        }

        // 7.5 is buffer for screen width, tailored for the build site
        if (enemyPosition.x > width - 7.5f || enemyPosition.x < -(width - 7.5f))
        {
            enemyPosition.x = -enemyPosition.x;
            transform.position = enemyPosition;
        }

        // 5.0 is buffer for the bottom of the screen, a little high vertically for destruction to be earlier
        if (transform.position.y < -(height - 5.0f))
        {
            Destroy(gameObject);
        }
    }
}
