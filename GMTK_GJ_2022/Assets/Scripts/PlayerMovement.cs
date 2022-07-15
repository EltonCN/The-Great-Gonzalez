using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalVelocity;
    PlayerControls controls;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        controls = new PlayerControls();

        controls.Default.Enable();
    }

    void FixedUpdate()
    {
        Vector2 input = controls.Default.Move.ReadValue<Vector2>();
        input *= horizontalVelocity;

        Vector3 velocity = Vector3.zero;

        velocity.x = input.x;
        velocity.z = input.y;

        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
