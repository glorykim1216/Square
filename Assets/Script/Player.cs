using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "square")
        {
            GameManager.gameOver = true;// Debug.Log("tag");
        }
        //Debug.Log("tag");
    }
}
