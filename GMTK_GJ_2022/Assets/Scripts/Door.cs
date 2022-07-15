using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject closedObject;
    [SerializeField] GameObject openObject;

    [SerializeField] bool closed;

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

    public void Open()
    {
        updateClosed(true);
    }

    void OnValidate()
    {
        updateClosed(closed, true);
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
