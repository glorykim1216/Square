using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour {
    public GameObject SquaresObj, PlayerObj, GameOverObj;
    Transform squaresTransform, playerTransform;

    public int speedBalance = 15;
    bool btnRight = false, btnLeft = false, end = true;

    public Text scoreS_Text, scoreM_Text, bestScore_Text;
    float time = 0, bestScore;
    int scoreS, scoreM;

    public Image gameOverBG;
    Color alpha = new Vector4(0, 0, 0, 0.05f);
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
            Score();
        }
        else
        {
            if (end == true)
            {
                End();
            }
        }
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
        scoreS_Text.text = scoreS.ToString();
        scoreM_Text.text = scoreM.ToString();//.PadLeft(2, '0');
        bestScore_Text.text = time.ToString();
    }
    void End()
    {
        StartCoroutine(Alpha());
        
        bestScore = PlayerPrefs.GetFloat("bestScore", bestScore);
        if (time > bestScore)
        {
            bestScore = time;
        }

        bestScore_Text.text = "BEST SCORE : " + Mathf.Floor(bestScore*100)/100; // 소수 2자리까지
        
        PlayerPrefs.SetFloat("bestScore", bestScore);
        PlayerPrefs.Save();

        GameOverObj.SetActive(true);

        end = false;
    }

    IEnumerator Alpha()
    {
        while (gameOverBG.color.a < 0.83f)
        {
            gameOverBG.color += alpha;
            yield return 0;
        }
    }

    public void ReGame()
    {
        SceneManager.LoadScene("start");
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
