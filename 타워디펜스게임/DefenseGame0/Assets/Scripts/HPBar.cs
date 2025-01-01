using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Transform monsterTransform; // 몬스터의 위치

    private void Update()
    {
        UpdatePosition(); // 매 프레임 체력바 위치 갱신
    }

    public void SetTarget(Transform newTarget)
    {
        monsterTransform = newTarget;

        // 체력바의 초기 위치를 즉시 설정
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (monsterTransform == null) return;

        // 1. 몬스터의 월드 좌표에 오프셋을 더함
        Vector3 adjustedWorldPosition = monsterTransform.position + new Vector3(0, 1, 0);

        // 2. 화면 좌표로 변환
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(adjustedWorldPosition);

        // 3. HP 바의 화면 좌표 설정
        transform.position = screenPosition;
    }

}
