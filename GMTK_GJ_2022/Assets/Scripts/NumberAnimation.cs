using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NumberAnimation : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] VisualEffect vfx;

    bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyed && vfx.aliveParticleCount == 0)
        {
            Destroy(this);
        }
    }

    public void DestroyAndAnimate()
    {
        destroyed = true;

        model.SetActive(false);
        vfx.gameObject.SetActive(true);
    }

}    
