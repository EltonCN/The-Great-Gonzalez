using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] List<DiceFace> faces;
    [SerializeField] List<GameObject> numberSprites;
    [SerializeField] GameObject body;
    [SerializeField] float[] info;
    [SerializeField] float movingMinimumVelocity = 0.01f;
    [SerializeField] bool destroyOnInteraction = true;
    [SerializeField] bool destroyOnStop = true;
    [SerializeField] float bodyHideDelay = 0.5f;
    [SerializeField] float destroyDelay = 1.45f;
    [SerializeField] bool showNumberOnDestroy = true;
    
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
            StartCoroutine(DestroyOnStop());
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
            StartCoroutine(DestroyOnStop());
        }
    
    }

    IEnumerator DestroyOnStop()
    {
        interact = false;
        
        int index = getNumber()-1;

        numberSprites[index].SetActive(true);

        yield return new WaitForSeconds(bodyHideDelay);

        body.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(destroyDelay);

        Destroy(this.gameObject);
    }
}
