using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    [SerializeField] GameObject target;
    // Start is called before the first frame update
    
    void FixedUpdate()
    {
        this.transform.rotation = target.transform.rotation;
    }

    void OnValidate()
    {
        this.transform.rotation = target.transform.rotation;
    }
}
