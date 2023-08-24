using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jacobAnimController : MonoBehaviour
{

    public NavMeshAgent nav;
    public Transform player;
    public Transform player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.velocity.x < 1.5)
        {
            this.GetComponent<Animator>().SetBool("Running", false);
        }
        if (nav.velocity.z < 1.5)
        {
            this.GetComponent<Animator>().SetBool("Running", false);
        }
        if (nav.velocity.x >= 1.5)
        {
            this.GetComponent<Animator>().SetBool("Running", true);
        }
        if (nav.velocity.z >= 1.5)
        {
            this.GetComponent<Animator>().SetBool("Running", true);
        }
    }
    public void Stun()
    {
        nav.isStopped = true;
        nav.gameObject.GetComponent<jacobAI>().stunned = true;
    }
    public void Unstun()
    {
        nav.isStopped = false;
        nav.gameObject.GetComponent<jacobAI>().patrolling = false;
        nav.gameObject.GetComponent<jacobAI>().stunned = false;
        player2 = player.transform;
        nav.SetDestination(player2.position);
    }
}
