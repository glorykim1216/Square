using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public GameObject Squares;
    public int speedBalance = 15;
    bool btnRight = false, btnLeft = false;

    public Text timeText1, timeText2;
    float time, bestScore;
    int scoreS, scoreM;
	// Update is called once per frame
	void Update () {
        SquaresRotation();
        Score();
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

    public void Score()
    {
        time += Time.deltaTime;
        scoreS = (int)time;
        if (scoreM > 95)
        {
            scoreM = 0;
        }
        scoreM += 2;
        timeText1.text = scoreS.ToString().PadLeft(2, '0');
        timeText2.text = scoreM.ToString().PadLeft(2, '0');
        //http://www.csharpstudy.com/Tip/Tip-number-format.aspx
        //http://pullthelever.tistory.com/339
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
