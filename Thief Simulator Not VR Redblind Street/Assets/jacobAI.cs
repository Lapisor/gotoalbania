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

    public Transform[] points;
    public int destPoint = 0;

    public bool real = false;
    public float timerToReal;

    public bool patrolling = true;

    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)

    private RaycastHit _mHitInfo;   // allocating memory for the raycasthit
    // to avoid Garbage
    private bool _bHasDetectedEnnemy = false;   // tracking whether the player
    // is detected to change color in gizmos
    public bool notDetecting;

    public float loseInterestTimer;
    public float loseInterestTimerMax = 4f;

    public bool losingInterest;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(SFXprobRangeLow, SFXprobRangeHigh);
        if (real)
        {
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            this.GetComponent<NavMeshAgent>().autoBraking = false;
            goToNextPoint();
        }
        loseInterestTimer = loseInterestTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (real && playerPos.GetComponent<playerValues>().nearJacob != true && patrolling != true)
        {
            this.GetComponent<NavMeshAgent>().SetDestination(playerPos.position);
        }
        if(real != true)
        {
            timerToReal -= 1 * Time.deltaTime;
        }
        if (timerToReal <= 0)
        {
            real = true;
        }
        if (!this.GetComponent<NavMeshAgent>().pathPending && this.GetComponent<NavMeshAgent>().remainingDistance < 0.5f && patrolling)
        {
            goToNextPoint();
        }
        if (losingInterest)
        {
            loseInterestTimer -= 1 * Time.deltaTime;
        }
        if(loseInterestTimer <= 0)
        {
            patrolling = true;
            losingInterest = false;
            loseInterestTimer = loseInterestTimerMax;
            this.GetComponent<NavMeshAgent>().isStopped = true;
            goToNextPoint();
        }
    }

    private void OnDrawGizmos()
    {
        if (_bHasDetectedEnnemy)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawCube(new Vector3(0f, 0f, mTargetDetectionDistance / 2f), new Vector3(mRaycastRadius, mRaycastRadius, mTargetDetectionDistance));
    }

    void FixedUpdate()
    {
        if (real)
        {
            CheckForTargetInLineOfSight();
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
            if(patrolling != true && notDetecting)
            {
                losingInterest = true;
            }
        }
        
    }

    void goToNextPoint()
    {
        this.GetComponent<NavMeshAgent>().isStopped = false;
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return;
        }

        // Set the agent to go to the currently selected destination.
        if (patrolling)
        {
            this.GetComponent<NavMeshAgent>().destination = points[destPoint].position;
        }
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        if (patrolling)
        {
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    public void CheckForTargetInLineOfSight()
    {
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);
        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.gameObject.tag == "Player")
            {
                notDetecting = false;
                patrolling = false;
                this.GetComponent<NavMeshAgent>().SetDestination(_mHitInfo.transform.position);
                // insert fighting logic here
            }
            else
            {
                notDetecting = true;
                Debug.Log("No Player detected");
                // no player detected, insert your own logic
            }
        }
        
    }
}
