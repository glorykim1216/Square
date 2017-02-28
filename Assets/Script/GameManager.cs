using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static float speed = 0.08f;
    public Square[] square = new Square[5];
    public Sphere sphere;
    int squareCount = 0, rotCount = 0, rotRandom = 0;
    float zPos = 0, zRot = 0;
    bool directionRight; // 방향

    enum State
    {
        Right,
        Left
    }

    State state = State.Right;

    // Use this for initialization
    void Start() {
        //StartCoroutine(a());
    }


    // Update is called once per frame
    void Update() {
        Reset();


    }

    public void Reset()
    {
        if (!square[squareCount].life)
        {
            RotationSet();
            PositionSet();
            square[squareCount].Create(zRot, zPos); // 추가 - 색상 랜덤 (매개변수)
            sphere.PositionSet(zPos);
            rotCount++;
            squareCount++;
            if (squareCount > 21)
            {
                squareCount = 0;
            }
        }
    }

    public void RotationSet()
    {
        // 방향 바꾸기(-), 같은 방향으로 몇번 생성(랜덤)
        if (rotCount == rotRandom)
        {
            directionRight = !(directionRight);
            rotCount = 0;
            rotRandom = Random.Range(3, 20);
            Debug.Log(rotRandom);
        }
        if (directionRight)
        {
            zRot += 3;
        }
        else
            zRot -= 3;
    }

    public void PositionSet()
    {
        zPos -= 0.001f;
    }

    IEnumerator a() // 추가 - 속도(밸런스)
    {
        yield return new WaitForSeconds(2);
        speed += 0.02f;
    }
}
