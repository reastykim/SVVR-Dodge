using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    public float rotateSpeed = 60f;

    // 컴퓨터 a : 60fps
    // 컴퓨터 b : 120fps
    // a : (Update()가 1초 60번) * (1회 60도) * (1/60) = 1초 동안 60도
    // b : (Update()가 1초 120번) * (1회 60도) * (1/120) = 1초 동안 60도
	void Update () {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
	}
}
