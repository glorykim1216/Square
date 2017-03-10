using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject particleCircle;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("square")) //.tag. CompareTag() "square")
        {
            GameManager.gameOver = true;
            SoundDie();
        }
        //Debug.Log("tag");
    }

    void SoundDie()
    {
        particleCircle.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
