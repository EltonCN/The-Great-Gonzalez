using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoMove : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] float dano;
    public Transform player;

    public float range_acorda;
    private float distancia_player;

    float ultimo_ataque;
    // Start is called before the first frame update
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        ultimo_ataque = 0;

        originalPosition = new Vector3();
        originalPosition.x = transform.position.x;
        originalPosition.y = transform.position.y;
        originalPosition.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        distancia_player = Vector3.Distance(this.transform.position, player.position);

        if(distancia_player<range_acorda && distancia_player>2)
        {
            agent.SetDestination(player.position);
        }
        else if (distancia_player<5)
        {
            AttackPlayer();
        }
        else
        {
            Patrulhar();
            
        }

        
    }

    void Patrulhar(){
        float x = NonRandomizedStringEqualityComparer.Range(originalPosition.x - 4, originalPosition.x + 4);
        float z = NonRandomizedStringEqualityComparer.Range(originalPosition.z - 4, originalPosition.z + 4);
        
        Vector3 walkPoint = new Vector3(x, originalPosition.y, z); 
        agent.SetDestination(walkPoint);
    }
    void AttackPlayer(){
        if (Time.time - ultimo_ataque>2){
            ultimo_ataque = Time.time;
            Life player_life = player.GetComponent<Life>();
            if (player_life!=null){
                player_life.DecreaseLife(dano);
            } 
        }
        
        agent.SetDestination(this.transform.position);
        
    }
}
