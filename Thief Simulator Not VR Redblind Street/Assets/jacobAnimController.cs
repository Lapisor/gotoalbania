using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jacobAnimController : MonoBehaviour
{

    public NavMeshAgent nav;

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
    }
    public void Unstun()
    {
        nav.isStopped = false;
    }
}
