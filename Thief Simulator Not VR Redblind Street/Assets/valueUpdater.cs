using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class valueUpdater : MonoBehaviour
{

    public playerValues player;
    public TextMeshProUGUI theText;
    public TextMeshProUGUI theWeightText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGoddammit()
    {
        theText.text = "£" + player.monies;
        theWeightText.text = player.weightCarried + "/2000";
    }
}
