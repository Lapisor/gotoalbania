using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class crowbarAttackScript : MonoBehaviour
{

    public float range;

    public Transform rayPoint;

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.GetComponent<Animator>().SetTrigger("Attack");
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
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
