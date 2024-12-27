using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit1Arrow : MonoBehaviour
{
    

    public GameObject arrow;

    public Transform pos;

    public bool hasArrow = false;



    public void StartArrowCreation()
    {
        if (!IsInvoking("ArrowCreate")) // 중복 호출 방지
        {
            InvokeRepeating("ArrowCreate", 1f, 2f); // 2초 간격으로 반복
        }
    }

    public void StopArrowCreation()
    {
        if (IsInvoking("ArrowCreate"))
        {
            CancelInvoke("ArrowCreate"); // 반복 중단
        }
    }

    public void ArrowCreate()
    {
        if (!hasArrow)
        {
            Debug.Log("활 생성");

            GameObject newArrow = Instantiate(arrow, pos.position, transform.rotation);

            hasArrow = true;

            // 생성된 화살에 Destroy 이벤트 연결
            Arrow unit1Arrow = newArrow.GetComponent<Arrow>();

            unit1Arrow.onDestroyed += ArrowDestroyed;

        }
    }

    private void ArrowDestroyed()
    {
        Debug.Log("활 파괴, hasArrow 초기화");
        hasArrow = false; // 화살이 파괴될 때 다시 생성 가능하도록 설정
    }
}
