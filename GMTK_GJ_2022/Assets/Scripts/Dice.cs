using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] List<DiceFace> faces;
    [SerializeField] float[] info;
    [SerializeField] float movingMinimumVelocity = 0.1f;
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
}
