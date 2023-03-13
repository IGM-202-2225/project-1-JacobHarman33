using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject straightshotEnemy;
    public GameObject erraticEnemy;
    public CollisionManager collisionManager;
    private float delayTime = 3f;
    private float nextSpawn;
    private float minX = 0.03f;
    private float maxY = 0.97f;
    private Vector3 pos;
    private float randChance;

    // Start is called before the first frame update
    void Start()
    {
        if(StaticFields.levelNum == 1)
        {
            nextSpawn = Time.time + delayTime;
            pos = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 1.05f, 10));
            collisionManager.collidableObjects.Add(Instantiate(straightshotEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
        }
        else if(StaticFields.levelNum == 2)
        {
            nextSpawn = Time.time + delayTime + 1f;
            pos = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 1.05f, 10));
            collisionManager.collidableObjects.Add(Instantiate(erraticEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
        }
        else if (StaticFields.levelNum == 3)
        {
            randChance = Random.Range(0.00f, 1.00f);
            if(randChance < 0.50f)
            {
                nextSpawn = Time.time + delayTime;
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 1.05f, 10));
                collisionManager.collidableObjects.Add(Instantiate(straightshotEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
            }
            else
            {
                nextSpawn = Time.time + delayTime;
                pos = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 1.05f, 10));
                collisionManager.collidableObjects.Add(Instantiate(erraticEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (StaticFields.levelNum == 1)
            {
                nextSpawn = Time.time + delayTime;
                pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(minX, maxY), 1.05f, 10));
                collisionManager.collidableObjects.Add(Instantiate(straightshotEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
            }
            else if (StaticFields.levelNum == 2)
            {
                nextSpawn = Time.time + delayTime;
                pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(minX, maxY), 1.05f, 10));
                collisionManager.collidableObjects.Add(Instantiate(erraticEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
            }
            else if (StaticFields.levelNum == 3)
            {
                randChance = Random.Range(0.00f, 1.00f);
                if (randChance < 0.50f)
                {
                    nextSpawn = Time.time + delayTime;
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(minX, maxY), 1.05f, 10));
                    collisionManager.collidableObjects.Add(Instantiate(straightshotEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
                }
                else
                {
                    nextSpawn = Time.time + delayTime;
                    pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(minX, maxY), 1.05f, 10));
                    collisionManager.collidableObjects.Add(Instantiate(erraticEnemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
                }
            }
        }
    }
}
