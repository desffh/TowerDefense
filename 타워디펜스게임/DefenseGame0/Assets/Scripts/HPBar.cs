using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HPBar : MonoBehaviour
{
    public Transform monsterTransform; // 몬스터의 위치

    private void Start()
    {

    }


    private void Update()
    { 

        // 1. 몬스터의 월드 좌표에 오프셋을 더함
        Vector3 adjustedWorldPosition = monsterTransform.position + new Vector3(0,1,0);

        // 2. 화면 좌표로 변환
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(adjustedWorldPosition);

        // 3. HP 바의 화면 좌표 설정
        transform.position = screenPosition;
    }

        public void SetTarget(Transform newTarget)
        {
            monsterTransform = newTarget;
            //Debug.Log($"HPBar에 {monsterTransform.name} 연결 완료");
        }

}
