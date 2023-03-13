using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightshotEnemy : MonoBehaviour
{
    private float velocity = 2f;
    private Vector3 direction = new Vector3(0, -1, 0).normalized;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }
}
