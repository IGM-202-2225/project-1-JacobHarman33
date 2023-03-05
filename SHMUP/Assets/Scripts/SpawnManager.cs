using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public CollisionManager collisionManager;
    private float delayTime = 3f;
    private float nextSpawn;
    private float min = 0.2f;
    private float max = 0.8f;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + delayTime;
            pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(min, max), 1.05f, 10));
            collisionManager.collidableObjects.Add(Instantiate(enemy, pos, Quaternion.Euler(0, 180, 0)).GetComponent<CollidableObject>());
        }
    }
}
