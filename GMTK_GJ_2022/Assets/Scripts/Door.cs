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

    public Transform outra_porta;
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
                    other.transform.position = outra_porta.transform.position;
                    updateClosed(true);
                }
                else
                {
                    rb.transform.position = outra_porta.transform.position;
                
                    if(rb.tag != "Dice")
                    {
                        updateClosed(true);
                    }
                }

                
            }
        //}

        porta_tp = outra_porta; 
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
