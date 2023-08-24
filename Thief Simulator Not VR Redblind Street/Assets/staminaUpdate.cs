using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaUpdate : MonoBehaviour
{

    public crowbarAttackScript stamina;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Slider>().value = stamina.cooldownTimer * -10 + 50;
    }
}
