using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class jacobRage : MonoBehaviour
{

    public jacobAI Jacob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Slider>().value = Jacob.GetComponent<NavMeshAgent>().acceleration;
    }
}
