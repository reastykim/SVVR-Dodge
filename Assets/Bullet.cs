using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 8f; // 총알 이동 속도
    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody bulletRigidbody;

	void Start () {
        // 자신의 게임 오브젝트에서 Rigidbody를 찾아가져오기
        bulletRigidbody = GetComponent<Rigidbody>();

        // 리지드바디의 속도 = 앞쪽 방향 * 속력
        // transform은 자신의 트랜스폼 컴포넌트를 즉시
        // 접근하는 지름길
        bulletRigidbody.velocity
            = transform.forward * speed;

        // 자신의 게임 오브젝트를 3초 뒤에 파괴
        Destroy(gameObject, 3f);
	}

    // 트리거 충돌 : 서로 뚫고 지나가는 충돌
    // 트리거 충돌시 자동실행 (입력으로 상대방 콜라이더가 옴)
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방의 태그가 Player 인가?
        if(other.gameObject.tag == "Player")
        {
            // 그러하다면, 상대방으로부터
            // PlayerController 컴포넌트를 가져오기
            PlayerController playerController
                = other.GetComponent<PlayerController>();
            // 플레이어 사망 실행
            playerController.Die();
        }
    }

    // 일반 충돌시 자동실행
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
}
