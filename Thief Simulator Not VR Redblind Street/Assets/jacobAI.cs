using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jacobAI : MonoBehaviour
{

    public Transform playerPos;
    public float timer;
    public int randSFX;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public float SFXprobRangeLow;
    public float SFXprobRangeHigh;

    public bool real = false;
    public float timerToReal;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(SFXprobRangeLow, SFXprobRangeHigh);
    }

    // Update is called once per frame
    void Update()
    {
        if (real && playerPos.GetComponent<playerValues>().nearJacob != true)
        {
            this.GetComponent<NavMeshAgent>().SetDestination(playerPos.position);
        }
        if(real != true)
        {
            timerToReal -= 1 * Time.deltaTime;
        }
        if (timerToReal <= 0)
        {
            //real = true;
        }
    }



    void FixedUpdate()
    {
        if (real)
        {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0)
            {
                randSFX = Random.Range(1, 4);
                timer = Random.Range(SFXprobRangeLow, SFXprobRangeHigh);

                if (randSFX == 1 && playerPos.gameObject.GetComponent<playerValues>().murderinTime != true)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(clip1, 0.3f);
                }
                if (randSFX == 2 && playerPos.gameObject.GetComponent<playerValues>().murderinTime != true)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(clip2, 0.3f);
                }
                if (randSFX == 3 && playerPos.gameObject.GetComponent<playerValues>().murderinTime != true)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(clip3, 0.3f);
                }
            }
        }
        
    }
}
