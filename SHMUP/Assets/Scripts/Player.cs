using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    Vector3 vehiclePosition = new Vector3(0, 0, 0);
    public float turnSpeed = 5f;
    public Vector2 direction = Vector2.right;
    public Vector2 velocity = Vector2.zero;
    private Vector2 movementInput;

    Camera cam;
    float height;
    float width;

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
        direction = movementInput;
        velocity = direction * turnSpeed * Time.deltaTime;
        transform.position += (Vector3)velocity;
        vehiclePosition = transform.position;

        // 7.5f is buffer for screen width, tailored for the build site but not optimized for the Unity editor
        if (vehiclePosition.x > width - 7.5f || vehiclePosition.x < -(width - 7.5f))
        {
            vehiclePosition.x = -vehiclePosition.x;
            transform.position = vehiclePosition;
        }

        // 4.5 is buffer for screen height which works in both the build site and the Unity editor
        if (vehiclePosition.y > height - 4.5 || vehiclePosition.y < -(height - 4.5))
        {
            vehiclePosition.y = -vehiclePosition.y;
            transform.position = vehiclePosition;
        }

        if (direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
