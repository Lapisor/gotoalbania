using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;

public class moneyCheck : MonoBehaviour
{

    public playerValues player;

    public string stringyThingy;

    // Start is called before the first frame update
    void Awake()
    {
        stringyThingy = "£" + player.monies.ToString();
        if(player.monies >= 20000)
        {
            Trophies.Unlock(206218);
        }
        if (player.monies >= 50000)
        {
            Trophies.Unlock(206278);
        }
        GameJolt.API.Scores.Add(Mathf.RoundToInt(player.monies), stringyThingy, 845072);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
