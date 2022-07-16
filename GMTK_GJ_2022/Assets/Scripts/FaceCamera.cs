using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }

    void OnValidate()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
