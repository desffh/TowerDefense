using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public GameObject hpBarPrefab; // HP 바 프리팹
    private GameObject hpBarInstance; // 생성된 HP 바 인스턴스

    private void Start()
    {
        CreateHPBar();
    }

    void CreateHPBar()
    {
        if (hpBarPrefab == null)
        {
            Debug.LogError("hpBarPrefab이 연결되지 않았습니다!");
            return;
        }

        // Canvas를 찾아서 HP 바를 추가
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("씬에 Canvas가 존재하지 않습니다!");
            return;
        }

        // HP 바 프리팹을 Canvas 아래에 생성
        hpBarInstance = Instantiate(hpBarPrefab, canvas.transform);

        // 체력바와 몬스터 연결
        Slider hpSlider = hpBarInstance.GetComponentInChildren<Slider>();
        if (hpSlider == null)
        {
            Debug.LogError("hpBarPrefab 내부에 Slider가 존재하지 않습니다!");
            return;
        }

        UnitStat unitstat = GetComponent<UnitStat>();
        if (unitstat == null)
        {
            Debug.LogError("UnitStat 컴포넌트가 Unit 오브젝트에 추가되지 않았습니다!");
            return;
        }

        // 체력바 연결
        unitstat.SetHPBar(hpSlider);

        // HP 바를 몬스터 위에 배치
        HPBar hpBarScript = hpBarInstance.GetComponent<HPBar>();
        if (hpBarScript != null)
        {
            hpBarScript.SetTarget(this.transform);
        }
        else
        {
            Debug.LogError("hpBarPrefab에 HPBar 스크립트가 존재하지 않습니다!");
        }
    }
}
