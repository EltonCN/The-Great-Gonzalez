using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent<int> diceInteractionEvent;
    [SerializeField] int minimumValue = 0;
    
    public void Interact(int diceValue)
    {
        if(diceValue < minimumValue)
        {
            return;
        }

        diceInteractionEvent.Invoke(diceValue);
    }

    void OnTriggerEnter(Collider other)
    {
    }
}
