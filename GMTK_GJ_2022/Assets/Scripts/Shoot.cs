using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] Transform origin;
    [SerializeField] float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
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

        if(context.phase != InputActionPhase.Performed)
        {
            return;
        }

        GameObject go = Instantiate(objectPrefab, origin.position, origin.rotation);
        Rigidbody rb = go.GetComponent<Rigidbody>();
       

        Vector3 direction  = origin.position-Camera.main.transform.position;
        direction.Normalize();


        rb.velocity = velocity*direction;

        
    }
}
