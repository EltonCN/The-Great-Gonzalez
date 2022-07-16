using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DiceFace : MonoBehaviour
{
    [SerializeField] int faceNumber;

    public float UpCoeficient
    {
        get
        {
            return transform.forward.y;
        }
        
    }

    public int FaceNumber
    {
        get
        {
            return this.faceNumber;
        }
    }
}
