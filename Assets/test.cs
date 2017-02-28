using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public float a;
    Color startColor = Color.red, stopColor = Color.yellow;// blue;
    Renderer myColor;
	// Use this for initialization
	void Start () {
        myColor = transform.GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {

        //AA();


    }
    public void AA()
    {
        //if (myColor.material.color == stopColor)
        //{
        //    int a;
        //    a = Random.Range(0, 5);
        //    switch (a)
        //    {
        //        case 0:
        //            stopColor = Color.blue;
        //            break;
        //        case 1:
        //            stopColor = Color.red;
        //            break;
        //        case 2:
        //            stopColor = Color.yellow;
        //            break;
        //        case 3:
        //            stopColor = Color.green;
        //            break;
        //        case 4:
        //            stopColor = Color.white;
        //            break;
        //    }

        //    //a = a / 10;
        //    //startColor = stopColor;
        //    //stopColor = Color.blue;//new Color(0,0,a/7f);
        //}
        myColor.material.color = new Color(0, a / 7f, a / 7f);
        //myColor.material.color = Color.Lerp(myColor.material.color, stopColor, 0.5f);
        //Debug.Log(Time.time);
    }
}
