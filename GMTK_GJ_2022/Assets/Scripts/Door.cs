using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private int porta_que_leva; 
    public Transform player;
    [SerializeField] GameObject closedObject;
    [SerializeField] GameObject openObject;

    [SerializeField] bool closed;

    [SerializeField] Transform porta1;
    [SerializeField] Transform porta2;
    private Transform porta_tp;
    void Start()
    {
        updateClosed(closed, true);
    }

    public void Toggle()
    {
        updateClosed(!closed);
    }

    public void Close()
    {
        updateClosed(true);
    }

    public void Open(int porta)
    {
        if (porta<=3)
            porta_tp = porta1;
        else
            porta_tp = porta2;
        updateClosed(false);
    }

    void OnValidate()
    {
        updateClosed(closed, true);
    }

    void OnTriggerEnter(Collider other)
    {
        //if(objeto.tag == "Player")
        //{
            if (closed == false)
            {
                Rigidbody rb = other.attachedRigidbody;
                
                if(rb == null)
                {
                    other.transform.position = porta_tp.transform.position;
                    updateClosed(true);
                }
                else
                {
                    rb.transform.position = porta_tp.transform.position;
                
                    if(rb.tag != "Dice")
                    {
                        updateClosed(true);
                    }
                }

                
            }
        //}

    }

    void updateClosed(bool newClosedState, bool force=false)
    {
        if(newClosedState == closed && !force)
        {
            return;
        }

        closed = newClosedState;

        closedObject.SetActive(closed);
        openObject.SetActive(!closed);
    }
}
