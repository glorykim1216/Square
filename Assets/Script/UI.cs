using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public GameObject SquaresObj, PlayerObj;
    Transform squaresTransform, playerTransform;

    public int speedBalance = 15;
    bool btnRight = false, btnLeft = false;

    public Text timeText1, timeText2, timeText3;
    float time, bestScore;
    int scoreS, scoreM;
    void Start()
    {
        squaresTransform = SquaresObj.GetComponent<Transform>();
        playerTransform = PlayerObj.GetComponent<Transform>();
    }
	// Update is called once per frame
	void Update () {
        if (GameManager.gameOver == false)
        {
            SquaresRotation();
        }
        //Score();
        // 추가 - 점수(시간초), 시작화면(페이드 인-아웃)
    }
    public void SquaresRotation()
    {
        if (btnRight)
        {
            squaresTransform.Rotate(0, 0, -GameManager.speed * speedBalance);
            playerTransform.Rotate(0, 0, -GameManager.speed * speedBalance);
        }
        else if (btnLeft)
        {
            squaresTransform.Rotate(0, 0, GameManager.speed * speedBalance);
            playerTransform.Rotate(0, 0, GameManager.speed * speedBalance);
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
        scoreS =(int)time;
        scoreM = (int)(time * 100 - (int)time * 100);
        timeText1.text = scoreS.ToString().PadLeft(2, '0');  

        timeText2.text = scoreM.ToString().PadLeft(2, '0');
        timeText3.text = time.ToString("F").PadLeft(2, '0');
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
