using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;

public class moneyCheck : MonoBehaviour
{

    public playerValues player;

    // Start is called before the first frame update
    void Awake()
    {
        if(player.monies >= 20000)
        {
            Trophies.Unlock(206218);
        }
        if (player.monies >= 50000)
        {
            Trophies.Unlock(206278);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
