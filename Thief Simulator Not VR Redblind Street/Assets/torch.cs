using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{

    public GameObject Torch;
    public bool On;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Torch"))
        {
            if (On)
            {
                Torch.SetActive(false);
                On = false;
            }
            else
            {
                Torch.SetActive(true);
                On = true;
            }
        }
    }
}
