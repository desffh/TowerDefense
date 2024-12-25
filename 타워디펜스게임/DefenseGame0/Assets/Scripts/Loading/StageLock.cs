using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageLock : MonoBehaviour
{
    // 현재 스테이지 번호
    private int stage;

    // 스테이지들
    private Button stageButton;

    private void Awake()
    {
        // 버튼 배열
        Button[] stages = GetComponentsInChildren<Button>();

        // 키값 가져오기
        stage = PlayerPrefs.GetInt("StageReached");

        // 스테이지들의 버튼 컴포넌트 비활성화
        for (int i = stage + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
        }
    }

}
