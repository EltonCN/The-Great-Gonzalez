using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] float maximumLife;
    [SerializeField] FloatVariable syncedVariable;
    void Start()
    {
        LifeValue = maximumLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }        
    }

    public void DecreaseLifeInt(int value)
    {
        DecreaseLife((float) value);
    }

    public void DecreaseLife(float value)
    {
        LifeValue -= value;
    }

    float LifeValue
    {
        set
        {
            this.life = value;

            if(syncedVariable != null)
            {
                syncedVariable.value = this.life;
            }
        }

        get
        {
            return this.life;
        }
    }
}
