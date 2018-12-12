using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigibody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigibody = GetComponent<Rigidbody>();

    }

    // 화면이 한번 새로 그려질때, 한번 실행됨 (평균적으로는 1초에 60번)
    void Update()
    {
        //if(Input.GetKey(KeyCode.W) == true)
        //{
        //    playerRigibody.AddForce(0,0,speed);
        //}
        //if(Input.GetKey(KeyCode.S) == true)
        //{
        //    playerRigibody.AddForce(0, 0, -speed);
        //}
        //if (Input.GetKey(KeyCode.A) == true)
        //{
        //    playerRigibody.AddForce(-speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.D) == true)
        //{
        //    playerRigibody.AddForce(speed, 0, 0);
        //}

        // 수평축과 수직축의 입력값을 감지하여 저장
        // GetAxis는 입력축의 음의 방향의 키 : -1.0
        // 아무것도 누르지않음 : 0.0
        // 양의 방향의 키 : +1.0

        // A <-            D ->
        // -1.0    0.0    +1.0
        float xInput = Input.GetAxis("Horizontal");
        // S v             W ^
        // -1.0    0.0    +1.0
        float zInput = Input.GetAxis("Vertical");


        // 실제 이동 속도를 입력값과 이동 속력을 통해 결정
        // -1.0 X speed = -speed
        // 0.0 x speed = 0
        // +1.0 x speed = speed
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigibody.velocity = newVelocity;
    }

    // 사망 처리
    public void Die()
    {
        // 자신의 게임 오브젝트로 접근하여 비활성화
        gameObject.SetActive(false);
        // 씬에 존재하는 게임 매니저를 찾아서, EndGame()으로 게임 오버 실행
        FindObjectOfType<GameManager>().EndGame();

        //GameManager gameManager = FindObjectOfType<GameManager>();
        //gameManager.EndGame();
    }
}
