using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    public readonly List<CollidableObject> collisions = new List<CollidableObject>();

    public bool isCurrentlyColliding = false;

    // Start is called before the first frame update
    void Start()
    {

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
                    Destroy(collisions[0].gameObject);
                    Destroy(gameObject);
                }
                else if (collisions[0] != null && gameObject.GetComponent<Player>() != null && collisions[0].GetComponent<EnemyBullet>() != null)
                {
                    Destroy(collisions[0].gameObject);
                }
                else if (collisions[0] != null && gameObject.GetComponent<Player>() != null && collisions[0].GetComponent<Enemy>() != null)
                {
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
