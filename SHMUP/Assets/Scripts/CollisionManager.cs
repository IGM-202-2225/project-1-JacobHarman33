using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<CollidableObject> collidableObjects = new List<CollidableObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (CollidableObject collidableObject in collidableObjects)
        {
            collidableObject.ResetCollision();
        }

        for (int i = 0; i < collidableObjects.Count; i++)
        {
            for (int j = i + 1; j < collidableObjects.Count; j++)
            {
                if(collidableObjects[i] != null && collidableObjects[j] != null)
                {
                    if (CollisionCheck(collidableObjects[i], collidableObjects[j]))
                    {
                        collidableObjects[i].RegisterCollision(collidableObjects[j]);
                        collidableObjects[j].isCurrentlyColliding = true;
                    }
                }
            }
        }
    }

    bool CollisionCheck(CollidableObject objA, CollidableObject objB)
    {
        Bounds boundsA = objA.GetComponent<SpriteRenderer>().bounds;
        Bounds boundsB = objB.GetComponent<SpriteRenderer>().bounds;

        if (boundsB.min.x < boundsA.max.x
            && boundsB.max.x > boundsA.min.x
            && boundsB.max.y > boundsA.min.y
            && boundsB.min.y < boundsA.max.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
