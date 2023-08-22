using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putOutFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactionFunction()
    {
        GetComponentInParent<ParticleSystem>().Stop();
        this.GetComponent<Animator>().SetTrigger("fireOut");
        GetComponentInParent<interactable>().displayMessage = "";
    }
}
