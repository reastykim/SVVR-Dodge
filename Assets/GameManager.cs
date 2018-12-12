using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 코드 가져오기
using UnityEngine.SceneManagement; // 씬 관리 코드 가져오기

public class GameManager : MonoBehaviour {
    public GameObject gameoverPannel; // 게임 오버 패널
    public Text timeText; // 시간 표시용 UI 텍스트
    public Text recordText; // 최고 기록 표시용 UI 텍스트

    private bool isGameover = false; // 게임 오버 상태를 표시
    private float surviveTime = 0f; // 생존 시간
	
	void Update () {
        // Esc 키를 누르면 프로그램 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // 게임 오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간을 갱신
            surviveTime = surviveTime + Time.deltaTime;
            // 텍스트 컴포넌트의 text 필드 값을, 생존 시간으로 변경
            timeText.text = "Time : " + Mathf.Round(surviveTime);
        }
        else
        {
            // 게임 오버가 맞다면, 게임 재시작 가능
            if(Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                // 같은 씬을 로드 => 게임 재시작이랑 같은 의미
                SceneManager.LoadScene("SampleScene");
            }
        }
	}
    // 현재 게임 상태를 게임 오버 상태로 만들기
    public void EndGame()
    {
        // 현재 상태를 게임 오버 상태로 만들기
        isGameover = true;
        // 게임 오버 표시용 UI를 활성화
        gameoverPannel.SetActive(true);
        
        // 과거에 BestTime이라는 키로 저장된 값을 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        // 이전의 최고 기록과 지금의 기록을 비교
        if (surviveTime > bestTime)
        {
            // 최고 기록 값을 현재 기록으로 덮어쓰기
            bestTime = surviveTime;
            // 변경된 최고 기록을 BestTime이라는 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        // 최고 기록을 텍스트로 표시
        recordText.text = "Best Time : " + Mathf.Round(bestTime);
    }
}
