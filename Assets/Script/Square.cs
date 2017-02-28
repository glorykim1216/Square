using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    public bool life = true;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Scale();
	}

    public void Scale()
    {
        if (life)
        {
            transform.localScale += new Vector3(GameManager.speed, GameManager.speed, 0);
            if (transform.localScale.x > 22)
            {
                life = false;
            }
        }
    }

    public void Create(float zRot, float zPos)
    {
        transform.localPosition = new Vector3(0, 0, zPos);
        transform.Rotate(0, 0, zRot);
        transform.localScale = new Vector3(0, 0, 1);
        life = true;
    }

}
