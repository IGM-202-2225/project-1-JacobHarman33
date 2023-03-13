using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public CollisionManager collisionManager;
    private Vector3 enemyPosition = new Vector3(0, 0, 0);
    private float latestBulletShotTime;
    private float bulletShotTime;
    private Camera cam;
    private float height;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        collisionManager = FindObjectOfType<CollisionManager>();
        if(StaticFields.levelNum == 1)
        {
            bulletShotTime = 0.33f;
        }
        else
        {
            bulletShotTime = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = transform.position;

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
        if (enemyPosition.y < -(height - 5.0f))
        {
            Destroy(gameObject);
        }
    }
}
