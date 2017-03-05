using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static float speed = 0.1f;
    public static bool gameOver = false;
    public Square[] square;

    int squareCount = 0, rotCount = 0, rotRandom = 0, colorSwitchPre = 0, colorSwitchPost = 0, colorRandomCount = 7;
    float zPos = 18, zRot = 45;
    int depth=18;
    bool directionRight; // 방향
    Color _color;

    // Use this for initialization
    void Start() {

    }


    // Update is called once per frame
    void FixedUpdate() {
        if (gameOver == false)
        {
            Reset();
        }
    }

    public void Reset()
    {
        if (!square[squareCount].life)
        {
            zRot = RotationSet(zRot);
            _color = ColorSet(squareCount);
            square[squareCount].Create(zRot, depth++, _color); 

            rotCount++;
            squareCount++;
            if (squareCount > 17)
            {
                squareCount = 0;
            }
        }
    }

    //각도 설정
    public float RotationSet(float zRot)
    {
        if (rotCount == rotRandom)
        {
            directionRight = !(directionRight);
            rotCount = 0;
            rotRandom = Random.Range(3, 30);
        }

        if (directionRight)
        {
            zRot += 15;
        }
        else
            zRot -= 15;

        return zRot;
    }

    // 색상 설정
    public Color ColorSet(int squareCount)
    {
        int _count = squareCount % 5 + 3;   // color 밝기

        colorRandomCount++;

        if (colorRandomCount >= 7)
        {
            colorRandomCount = 0;

            // switch에 들어갈 colorSwitchPost 구하기
            while (true)
            {
                colorSwitchPost = Random.Range(0, 8);
                if (colorSwitchPre == colorSwitchPost)
                {
                    continue;
                }
                break;
            }
            colorSwitchPre = colorSwitchPost;
        }
      
        // 색상 선택
        switch (colorSwitchPost)
        {
            case 0:
                _color = new Color(_count / 7f, _count / 7f, _count / 7f);
                break;
            case 1:
                _color = new Color(0, _count / 7f, _count / 7f);
                break;
            case 2:
                _color = new Color(_count / 7f, 0, _count / 7f);
                break;
            case 3:
                _color = new Color(_count / 7f, _count / 7f, 0);
                break;
            case 4:
                _color = new Color(0, 0, _count / 7f);
                break;
            case 5:
                _color = new Color(0, _count / 7f, 0);
                break;
            case 6:
                _color = new Color(_count / 7f, 0, 0);
                break;

            default:    //case 7:
                _color = new Color(1, 0, _count / 7f);
                break;
        }
        return _color;
    }

    IEnumerator a() // 추가 - 속도(밸런스)
    {
        yield return new WaitForSeconds(2);
        speed += 0.02f;
    }
}
