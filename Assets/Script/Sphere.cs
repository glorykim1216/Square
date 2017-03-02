using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    Vector3 pos = new Vector3(0, -3.5f, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 추가 - 계속 회전
        // collider 확인
	}
    public void PositionSet(float zPos)
    {
        pos.z = zPos;
        transform.localPosition = pos;
    }
}
