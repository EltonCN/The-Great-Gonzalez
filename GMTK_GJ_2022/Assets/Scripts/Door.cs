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
        updateClosed(false);
    }

    public void Open(int porta)
    {
        Debug.Log("aaa");
    }

    void OnValidate()
    {
        updateClosed(closed, true);
    }

    void OnTriggerEnter(Collider objeto){
        if (objeto.gameObject.name == "Player"){
            if (closed == false){
                objeto.transform.position = outra_porta.transform.position;
            }
            print("hahahahhaha");
            
        }
        else if (objeto.gameObject.name == "Cube"){
            Debug.Log("aaaaa");
            updateClosed(false);
        }
        porta_tp = outra_porta;
        
    }

    void OnCollisionEnter(Collision collision)
    {
       
            
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
