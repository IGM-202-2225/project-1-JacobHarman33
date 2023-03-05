using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;

    private Camera cam;
    private float height;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        // 7.5 is buffer for screen width, tailored for the build site
        if (transform.position.x > width - 7.5f || transform.position.x < -(width - 7.5f))
        {
            Destroy(gameObject);
        }

        // 4.5 is buffer for screen height, tailored for the build site
        if (transform.position.y > height - 4.5f || transform.position.y < -(height - 4.5f))
        {
            Destroy(gameObject);
        }
    }
}
