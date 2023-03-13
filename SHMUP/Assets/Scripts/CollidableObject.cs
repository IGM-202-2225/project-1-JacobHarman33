using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    public readonly List<CollidableObject> collisions = new List<CollidableObject>();
    public LivesManager livesManager;
    public PointsManager pointsManager;
    public bool isCurrentlyColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        livesManager = FindObjectOfType<LivesManager>();
        pointsManager = FindObjectOfType<PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisions.Count != 0)
        {
            if (isCurrentlyColliding)
            {
                if (gameObject.GetComponent<Enemy>() != null && collisions[0].GetComponent<PlayerBullet>() != null)
                {
                    if (gameObject.GetComponent<ErraticEnemy>() != null)
                    {
                        StaticFields.pointsNum += 2000;
                    }
                    else
                    {
                        StaticFields.pointsNum += 1000;
                    }
                    Destroy(collisions[0].gameObject);
                    Destroy(gameObject);
                }
                else if (collisions[0] != null && gameObject.GetComponent<Player>() != null && collisions[0].GetComponent<EnemyBullet>() != null)
                {
                    if (livesManager.numOfLives != 0)
                    {
                        livesManager.numOfLives -= 1;
                    }
                    Destroy(collisions[0].gameObject);
                }
                else if (collisions[0] != null && gameObject.GetComponent<Player>() != null && collisions[0].GetComponent<Enemy>() != null)
                {
                    if(livesManager.numOfLives != 0)
                    {
                        livesManager.numOfLives -= 1;
                    }
                    Destroy(collisions[0].gameObject);
                }
            }
        }
    }

    public void RegisterCollision(CollidableObject other)
    {
        isCurrentlyColliding = true;
        collisions.Add(other);
    }

    public void ResetCollision()
    {
        isCurrentlyColliding = false;
        collisions.Clear();
    }
}
