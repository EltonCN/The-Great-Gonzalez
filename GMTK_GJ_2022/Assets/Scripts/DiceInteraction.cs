using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent<int> diceInteractionEvent;
    
    public void Interact(int diceValue)
    {
        diceInteractionEvent.Invoke(diceValue);
    }

    void OnTriggerEnter(Collider other)
    {
    }
}
