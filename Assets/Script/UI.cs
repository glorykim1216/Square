using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public GameObject SquaresObj, PlayerObj, GameOverObj;
    Transform squaresTransform, playerTransform;

    public int speedBalance = 15;
    bool btnRight = false, btnLeft = false, end = true;

    public Text scoreS_Text, scoreM_Text, bestScore_Text;
    float time = 0, bestScore;
    int scoreS, scoreM, speedCheck = 5;

    public Image gameOverBG;
    Color alpha = new Vector4(0, 0, 0, 0.05f);

    void Start()
    {
        squaresTransform = SquaresObj.GetComponent<Transform>();
        playerTransform = PlayerObj.GetComponent<Transform>();

    }

    void Update()
    {
        if (GameManager.gameOver == false)
        {
            SquaresRotation();
            Score();
            Speed();
        }
        else
        {
            if (end == true)
            {
                End();
            }
        }
    }

    void SquaresRotation()
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


    void Score()
    {
        time += Time.deltaTime;
        scoreS = (int)time;
        if (scoreM > 95)
        {
            scoreM = 0;
        }
        scoreS = (int)time;
        scoreM = (int)(time * 100 - (int)time * 100);
        scoreS_Text.text = scoreS.ToString();
        scoreM_Text.text = scoreM.ToString();
        bestScore_Text.text = time.ToString();
    }

    void Speed()
    {
        if (time > speedCheck)
        {
            GameManager.speed += 0.01f;
            speedCheck += 5;
        }
    }

    void End()
    {
        StartCoroutine(Alpha());

        bestScore = PlayerPrefs.GetFloat("bestScore", bestScore);
        if (time > bestScore)
        {
            bestScore = time;
        }

        bestScore_Text.text = "BEST SCORE : " + Mathf.Floor(bestScore * 100) / 100; // 소수 2번째 자리까지

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

    // Button
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
