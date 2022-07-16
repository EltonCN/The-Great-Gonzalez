using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    Rigidbody rb;
    public float range_acorda;

    private float distancia_player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia_player = Vector3.Distance (this.transform.position, player.position);
        if(distancia_player<range_acorda && distancia_player>2){
            agent.SetDestination(player.position);
        }
        else if (distancia_player<5){
            AttackPlayer();
        }

        
    }
    void AttackPlayer(){
        agent.SetDestination(this.transform.position);
    }
}
