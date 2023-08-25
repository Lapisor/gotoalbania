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
            isCrouching = true;
            this.GetComponent<CharacterController>().height = crouchedSize;
            Jacob.mTargetDetectionDistance = crouchedDetection;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            this.GetComponent<CharacterController>().height *= 1.3f;
            this.GetComponent<CharacterController>().height = regSize;
            Jacob.mTargetDetectionDistance = regDetection;
        }
    }
}
