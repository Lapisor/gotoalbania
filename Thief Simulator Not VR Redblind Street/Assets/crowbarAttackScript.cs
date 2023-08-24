using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class crowbarAttackScript : MonoBehaviour
{

    public float range;

    public Transform rayPoint;

    public LayerMask layerMask;

    public bool coolindownin;
    public float cooldownTimer;
    public float cooldown;

    public GameObject staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && coolindownin != true)
        {
            cooldownTimer = cooldown;
            this.GetComponent<Animator>().SetTrigger("Attack");
            coolindownin = true;
        }
        if (coolindownin)
        {
            staminaBar.SetActive(true);
        }
        else
        {
            staminaBar.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (coolindownin)
        {
            cooldownTimer -= 1 * Time.deltaTime;
        }
        if(cooldownTimer <= 0)
        {
            coolindownin = false;
            cooldownTimer = cooldown;
        }
    }

    public void attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayPoint.position, rayPoint.TransformDirection(Vector3.forward), out hit, range, layerMask))
        {
            Debug.Log("Hit a thing");
            if (hit.transform.gameObject.tag == "jacob")
            {
                hit.transform.gameObject.GetComponentInChildren<Animator>().SetTrigger("Hit");
                Debug.Log("Hit a Jacob thing");
                hit.transform.gameObject.GetComponent<jacobAI>().patrolling = false;
                hit.transform.gameObject.GetComponent<NavMeshAgent>().SetDestination(GetComponentInParent<crouchScript>().gameObject.transform.position);
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
