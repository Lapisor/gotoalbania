﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerNextScene : MonoBehaviour
{
    public int nextScene;

    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadScene(nextScene);
    }
}
