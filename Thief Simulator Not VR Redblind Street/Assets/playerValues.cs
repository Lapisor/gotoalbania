
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class playerValues : MonoBehaviour
{

    public float monies;
    public float weightCarried;
    public Collider Jacob;
    public AudioClip deathSound;
    public GameObject deathScreen;
    public float deathTimer;
    public bool countingDown;
    public bool murderinTime;
    public AudioSource deathSFXplayer;

    public bool nearJacob;
    public float maxDeathTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        deathTimer = maxDeathTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countingDown)
        {
            deathTimer -= 1 * Time.deltaTime;
        }
        if (deathTimer <= 0)
        {
            if(nearJacob != true)
            {
                maxDeathTime -= 0.1f;
            }
            deathTimer = maxDeathTime;
            murderinTime = true;
            countingDown = false;
        }
    }

    public void OnTriggerEnter(Collider Jacob)
    {
        
        if (Jacob.tag == "jacob")
        {
            if(nearJacob != true)
            {
                deathSFXplayer.PlayOneShot(deathSound, 1);
            }
            countingDown = true;
            nearJacob = true;
        }
        if (Jacob.tag == "jacob extra")
        {
            Jacob.gameObject.GetComponentInParent<NavMeshAgent>().SetDestination(this.transform.position);
        }
    }
    public void OnTriggerStay(Collider Jacob)
    {
        if (Jacob.tag == "jacob")
        {
            Jacob.GetComponent<NavMeshAgent>().isStopped = true;
            if (murderinTime && Jacob.GetComponent<jacobAI>().stunned != true)
            {
                deathScreen.SetActive(true);
                this.GetComponent<FirstPersonController>().enabled = false;
            }
        }
        
    }

    public void OnTriggerExit(Collider Jacob)
    {
        if (Jacob.tag == "jacob")
        {
            Jacob.GetComponent<NavMeshAgent>().isStopped = false;
            nearJacob = false;
        }
    }

}
