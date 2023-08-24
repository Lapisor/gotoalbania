using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class pauseMenu : MonoBehaviour
{

    public bool isPaused;

    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                this.GetComponent<FirstPersonController>().enabled = true;
                Cursor.visible = false;
            }
            else
            {
                isPaused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0.01f;
                this.GetComponent<FirstPersonController>().enabled = false;
                Cursor.visible = true;
            }
        }
    }
}
