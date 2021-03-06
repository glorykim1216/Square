﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject effect, playBtn;
    Transform effectSize;
    Vector3 size = new Vector3(0.2f, 0.2f, 0);

    void Start()
    {
        effectSize = effect.GetComponent<Transform>();
    }

    void Update()
    {
        if (effectSize.localScale.x < 18)
        {
            effectSize.localScale += size;
            if (effectSize.localScale.x > 18)
            {
                playBtn.SetActive(true);
            }
        }
    }

    void Play()
    {
        SceneManager.LoadScene("square");
    }
}
