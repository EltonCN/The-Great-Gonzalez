using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] float life;
    [SerializeField] float maximumLife;
    void Start()
    {
        life = maximumLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }        
    }

    public void DecreaseLife(int value)
    {
        print(value);
        this.life -= value;
    }
}
