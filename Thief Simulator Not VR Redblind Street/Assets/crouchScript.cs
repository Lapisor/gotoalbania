using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class crouchScript : MonoBehaviour
{

    public bool isCrouching;

    public float crouchedSpeed;
    public float regSpeed;

    public float crouchedSize;
    public float regSize;

    public jacobAI Jacob;
    public float regDetection;
    public float crouchedDetection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            this.GetComponent<FirstPersonController>().m_WalkSpeed = 1.5f * ((2000 - this.GetComponent<playerValues>().weightCarried) / 3000);
            this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 3 * ((2000 - this.GetComponent<playerValues>().weightCarried) / 3000);
            this.GetComponent<CharacterController>().height = crouchedSize;
            Jacob.mTargetDetectionDistance = crouchedDetection;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            this.GetComponent<FirstPersonController>().m_WalkSpeed = 3 * ((2000 - this.GetComponent<playerValues>().weightCarried) / 3000);
            this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 6 * ((2000 - this.GetComponent<playerValues>().weightCarried) / 3000);
            this.GetComponent<CharacterController>().height *= 1.3f;
            this.GetComponent<CharacterController>().height = regSize;
            Jacob.mTargetDetectionDistance = regDetection;
        }
    }
}
