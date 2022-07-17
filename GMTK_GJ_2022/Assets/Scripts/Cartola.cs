using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartola : MonoBehaviour
{
    // Start is called before the first frame update
    float cooldown;
    [SerializeField] GameObject coelho;
    void Start()
    {
        cooldown = 0;
        coelho.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coelho.active && Time.time - cooldown>1){
            coelho.SetActive(false);
        }
        
    }

    void OnTriggerEnter(Collider objeto){
        
        if (objeto.gameObject.name == "Player" && Time.time - cooldown>2){
            cooldown = Time.time;
            coelho.SetActive(true);
        }
            
        
    }
}
