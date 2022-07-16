using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float horizontalVelocity;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] Transform forwardReference;
    PlayerControls controls;

    bool jumping = false;
    bool cancelada = false;

    

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

        Vector3 velocity = ( forwardReference.right * input.x + forwardReference.forward * input.y);

        velocity.y = rb.velocity.y;

        if(jumping)
        {
            rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
            jumping = false;
        }

        rb.velocity = velocity;
    }

    public void Jump(InputAction.CallbackContext context)
    {        
        if(context.phase == InputActionPhase.Canceled)
        {
            cancelada = true;
        }

        if(context.phase == InputActionPhase.Performed && Mathf.Abs(rb.velocity.y) <= 0.1f  && cancelada)
        {
            jumping = true;
            cancelada = false;
        }
        else
        {
            jumping = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
