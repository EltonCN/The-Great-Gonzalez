using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coelho : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float dano;
    [SerializeField] GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider objeto){
        
        if (objeto.gameObject.name == "Player"){
            this.gameObject.SetActive(false);
            Life player_life = player.GetComponent<Life>();
            if (player_life!=null){
                player_life.DecreaseLife(dano);
            } 
            
        }
            
        
    }
}
