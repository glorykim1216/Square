using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static float speed = 0.05f;
    public Square[] square = new Square[5];
    public Sphere sphere;
    int squareCount = 0, rotCount = 0, rotRandom = 0;
    float zPos = 0, zRot = 5;
    bool direction; // 방향
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
            square[squareCount].Create(RotationSet(), PositionSet()); // 추가 - 색상 랜덤 (매개변수)
            sphere.PositionSet(zPos);
            rotCount++;
            squareCount++;
            if (squareCount > 20)
            {
                squareCount = 0;
            }
        }
    }

    public float RotationSet()
    {
        if (rotCount == rotRandom)
        {
            zRot -= 5;
            //zRot = -zRot;
            rotCount = 0;
            rotRandom = Random.Range(1, 6);
            Debug.Log(rotRandom);
        }
        else
        zRot += 5;
        // 방향 바꾸기(-), 같은 방향으로 몇번 생성(랜덤)
        return zRot;
    }

    public float PositionSet()
    {
        zPos -= 0.001f;
        return zPos;
    }

    IEnumerator a() // 추가 - 속도(밸런스)
    {
        yield return new WaitForSeconds(2);
        speed += 0.02f;
    }
}
