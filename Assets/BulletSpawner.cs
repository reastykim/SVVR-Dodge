using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public GameObject bulletPrefab; // 생성할 총알 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    void Start () {
        timeAfterSpawn = 0f; // 타이머를 리셋
        // spawnRateMin과 spawnRateMax 사이의 랜던 값을 사용
        spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        // FindObjectOfType은 씬에 존재하는 모든 오브젝트를 검색
        // 하여 원하는 타입의 오브젝트를 찾아옴
        target = FindObjectOfType<PlayerController>().transform;

        //PlayerController playerController
        //    = FindObjectOfType<PlayerController>();
        //target = playerController.transform;
	}

    // 1/60초 마다 실행됨
    // 1회 실행 마다 : timeAfterSpawn = timeAfterSpawn + 1/60
    // 100번 실행 -> 현실시간으로는 100/60초, timeAfterSpawn = 100/60

    // 게임 화면이 한번 갱신될때 한번 실행됨
	void Update () {

        // Time.deltaTime은 직전의 Update와 현재 Update 실행 시점
        // 사이의 시간 간격
        timeAfterSpawn = timeAfterSpawn + Time.deltaTime;
        // 누적된 시간이 생성 주기보다 크거나 같다
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f; // 누적된 시간을 리셋

            // bulletPrefab의 복제본을 생성
            // 위치와 회전은 총알 생성기 자신의 위치와 회전으로 지정.
            // 생성된 총알 복제본을 bullet 이라는 변수로 다루기
            GameObject bullet = Instantiate(bulletPrefab,
                transform.position,transform.rotation);

            // 총알이 target을 바라보도록 회전
            bullet.transform.LookAt(target);

            // 다음번 생성까지의 생성 간격을 랜덤하게 변경
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
	}
}
