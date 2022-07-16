using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] List<DiceFace> faces;
    [SerializeField] float[] info;
    [SerializeField] float movingMinimumVelocity = 0.01f;
    [SerializeField] bool destroyOnInteraction = true;
    [SerializeField] bool destroyOnStop = true;
    [SerializeField] float destroyOnStopDelay = 0.5f;
    
    bool interact = true;
    float movingMinimumVelocity2;

    Rigidbody rb;

    bool moving;

    void Start()
    {
        info = new float[6];
        moving = false;
        movingMinimumVelocity2 = movingMinimumVelocity*movingMinimumVelocity;

        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        checkMoving();

        if(destroyOnStop && !moving)
        {
            Destroy(this.gameObject);
        }
    }

    void checkMoving()
    {
        if(rb.velocity.sqrMagnitude < movingMinimumVelocity2)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }

    public int getNumber()
    {
        float maximumCoeficient = float.MinValue;
        int number = 0;

        foreach(DiceFace face in faces)
        {
            float UpCoeficient = face.UpCoeficient;
            if(UpCoeficient> maximumCoeficient)
            {
                maximumCoeficient = UpCoeficient;
                number = face.FaceNumber;
            }

            info[face.FaceNumber-1] = UpCoeficient;
        }

        return number;
    }

    void OnValidate()
    {
        movingMinimumVelocity2 = movingMinimumVelocity*movingMinimumVelocity;
    }

    bool Moving
    {
        get
        {
            return moving;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!interact)
        {
            return;
        }

        Rigidbody rb = other.attachedRigidbody;

        if(rb == null)
        {
            return;
        }

        DiceInteraction di = rb.GetComponent<DiceInteraction>();
        
        
        if(di == null && this.destroyOnInteraction)
        {
            return;
        }

        di.Interact(getNumber());

        if(this.destroyOnInteraction)
        {
            Destroy(this.gameObject);
            interact = false;
        }
    
    }

    IEnumerator DestroyOnStop()
    {
        if(destroyOnStopDelay > 0)
        {
            yield return new WaitForSeconds(destroyOnStopDelay);
        }

        Destroy(this.gameObject);
    }
}
