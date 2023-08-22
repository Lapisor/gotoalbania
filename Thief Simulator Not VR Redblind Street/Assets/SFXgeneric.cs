using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXgeneric : MonoBehaviour
{

    public AudioClip clip1;
    public AudioClip clip2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SFX1()
    {
        this.GetComponent<AudioSource>().PlayOneShot(clip1, 0.5f);
    }
    public void SFX2()
    {
        this.GetComponent<AudioSource>().PlayOneShot(clip1, 0.5f);
    }
}
