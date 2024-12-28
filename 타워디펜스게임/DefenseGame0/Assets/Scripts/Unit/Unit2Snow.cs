using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2Snow : MonoBehaviour
{
    public GameObject snow;

    public Transform pos;

    public bool hasSnow = false;

    public void ActiveFalse()
    {
        hasSnow = false;
    }


    public void StartSnowCreation()
    {
        if (!IsInvoking("SnowCreate")) // 중복 호출 방지
        {
            InvokeRepeating("SnowCreate", 1f, 2f); // 2초 간격으로 반복
        }
    }

    public void StopSnowCreation()
    {
        if (IsInvoking("SnowCreate"))
        {
            CancelInvoke("SnowCreate"); // 반복 중단
        }
    }

    public void SnowCreate()
    {
        if (!hasSnow)
        {
            Debug.Log("눈 생성");

            GameObject newSnow = Instantiate(snow, pos.position, transform.rotation);

            // 생성된 화살을 유닛의 자식으로 설정
            newSnow.transform.parent = this.transform;

            hasSnow = true;

            // 생성된 화살에 Destroy 이벤트 연결
            Snow unit2snow = newSnow.GetComponent<Snow>();

            if (unit2snow != null)
            {
                unit2snow.onDestroyed += SnowDestroyed;
            }

        }
    }

    private void SnowDestroyed()
    {
        Debug.Log("눈 파괴, hasSnow 초기화");
        hasSnow = false; // 눈이 파괴될 때 다시 생성 가능하도록 설정
    }
}
