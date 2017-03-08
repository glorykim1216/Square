using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    public bool life = true;
    Renderer color_sortOrder;
    Vector3 size = Vector3.zero, sizeReset = new Vector3(0,0,1);
    // Use this for initialization
    void Start () {
        color_sortOrder = transform.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameOver == false)
        {
            Scale();
        }
	}

    public void Scale()
    {
        if (life)
        {
            size.x = GameManager.speed;
            size.y = GameManager.speed;
            transform.localScale += size;
            if (transform.localScale.x > 18)
            {
                life = false;
            }
        }
    }

    public void Create(float zRot, int zPos, Color _color)
    {
        color_sortOrder.material.color = _color;
        //transform.localPosition = new Vector3(0, 0, zPos);
        transform.localRotation = Quaternion.Euler(0, 0, zRot);
        //2017-03-02 transfor.Rotation(0,0,zRot); -> 가끔 씹힘
        color_sortOrder.sortingOrder = zPos;
        transform.localScale = sizeReset;
        life = true;

    }

}
