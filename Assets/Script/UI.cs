using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public GameObject Squares;
    public int speedBalance = 15;
    bool btnRight = false, btnLeft = false;
	
	// Update is called once per frame
	void Update () {
        SquaresRotation();
        // 추가 - 점수(시간초)
    }
    public void SquaresRotation()
    {
        if (btnRight)
        {
            Squares.GetComponent<Transform>().Rotate(0, 0, -GameManager.speed * speedBalance);
        }
        if (btnLeft)
        {
            Squares.GetComponent<Transform>().Rotate(0, 0, GameManager.speed * speedBalance);
        }
    }

    public void BtnSpeed(float a)
    {
        GameManager.speed += a;
    }
    public void BtnRightDown()
    {
        btnRight = true;
    }
    public void BtnRightUp()
    {
        btnRight = false;
    }
    public void BtnLeftDown()
    {
        btnLeft = true;
    }
    public void BtnLeftUp()
    {
        btnLeft = false;
    }
}
