using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHider : MonoBehaviour
{

    public bool mouseHidden;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHidden)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
