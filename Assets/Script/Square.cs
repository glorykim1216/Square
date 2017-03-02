using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    public bool life = true;
    Renderer myColor;

    // Use this for initialization
    void Start () {
        myColor = transform.GetComponent<Renderer>();
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

    public void Create(float zRot, float zPos, Color _color)
    {
        myColor.material.color = _color;
        transform.localPosition = new Vector3(0, 0, zPos);
        transform.localRotation = Quaternion.Euler(0, 0, zRot);
        //2017-03-02 transfor.Rotation(0,0,zRot); -> 가끔 씹힘
        transform.localScale = new Vector3(0, 0, 1);
        life = true;

    }

}
