using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] List<DiceFace> faces;
    [SerializeField] List<GameObject> numberSprites;
    [SerializeField] GameObject body;
    [SerializeField] float movingMinimumVelocity = 0.01f;
    [SerializeField] bool destroyOnInteraction = true;
    [SerializeField] bool destroyOnStop = true;
    [SerializeField] float bodyHideDelay = 0.5f;
    [SerializeField] float destroyDelay = 1.45f;
    [SerializeField] bool showNumberOnDestroy = true;
    [SerializeField] bool explode = false;
    [SerializeField] float explodeRange = 4f;
    bool interact = true;
    float movingMinimumVelocity2;

    Rigidbody rb;

    bool moving;

    void Start()
    {
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
            interact = false;
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

        int number = getNumber();
        bool interacted = false;

        if(explode == true)
        {
            interacted = Explode(number);
        }
        else
        {
            interacted = interactWith(other, number);
            
        }

        if(this.destroyOnInteraction && interacted)
        {
            StartCoroutine(DestroyOnStop());
            interact = false;
        }
    
    }

    bool interactWith(Collider other, int number)
    {
        Rigidbody rb = other.attachedRigidbody;
        DiceInteraction di = null;
        if(rb != null)
        {
            di = rb.GetComponent<DiceInteraction>();
        }
        else
        {
            di = other.GetComponent<DiceInteraction>();
        }
        
        if(di == null)
        {
            return false;
        }

        di.Interact(number);

        return true;

    }

    bool Explode(int number)
    {
        explode = false;
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, explodeRange);

        bool interacted = false;

        foreach (Collider hitCollider in hitColliders)
        {
            bool interactedWithThis = interactWith(hitCollider, number);

            interacted = interactedWithThis || interacted;
            
        }

        return interacted;

    }

    IEnumerator DestroyOnStop()
    {
        if(!interact)
        {
            yield break;
        }

        interact = false;
        
        int index = getNumber()-1;

        if(showNumberOnDestroy && numberSprites.Count>index)
        {
            if(numberSprites[index] != null)
            {
                numberSprites[index].SetActive(true);
            }
            
        }
        

        yield return new WaitForSeconds(bodyHideDelay);

        body.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(destroyDelay);

        Destroy(this.gameObject);
    }
}
