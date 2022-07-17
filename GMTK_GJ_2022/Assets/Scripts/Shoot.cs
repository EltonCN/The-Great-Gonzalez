using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] Transform origin;
    [SerializeField] float velocity;
    [SerializeField] Rigidbody shooterVelocityReference;
    [SerializeField] bool randomizeRotation = true;
    [SerializeField] float shootCooldown = 1f;
    float lastShoot;

    void Start()
    {
        lastShoot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction  = origin.position-Camera.main.transform.position;
        direction.Normalize();
        Debug.DrawRay(origin.position, direction, Color.green);

    }

    public void shootObject(InputAction.CallbackContext context)
    {
        if(!this.isActiveAndEnabled)
        {
            return;
        }
        if(context.phase != InputActionPhase.Performed)
        {
            return;
        }

        if(Time.time-lastShoot < shootCooldown)
        {
            return;
        }
        lastShoot = Time.time;

        Quaternion rotation = origin.rotation;
        if(randomizeRotation)
        {
            Vector3 angles = new Vector3();
            angles.x = Random.Range(0,360);
            angles.y = Random.Range(0,360);
            angles.z = Random.Range(0,360);

            rotation.eulerAngles = angles;
        }

        GameObject go = Instantiate(objectPrefab, origin.position, rotation);
        Rigidbody rb = go.GetComponent<Rigidbody>();
       

        Vector3 direction  = origin.position-Camera.main.transform.position;
        direction.Normalize();

        float realVelocity = velocity;

        if(shooterVelocityReference != null)
        {
            realVelocity += shooterVelocityReference.velocity.magnitude;
        }
        
        rb.velocity = realVelocity*direction;

        
    }
}
