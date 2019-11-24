using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContoller : MonoBehaviour
{
    public ActorStats Stats;
    public NavMeshAgent Agent;
    public GameObject Player;
    public Rigidbody body;

    void Start()
    {
        Agent.speed *= Stats.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Player.transform.position);

        if (Stats.HP <= 0)
        {
            Player.GetComponent<ActorStats>().Frags++;
            Player.GetComponent<ActorStats>().HP += 10;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<ActorStats>().GetDamage(Stats.TouchDamage);
            body.AddForce(-transform.forward*100);
        }
    }
}
