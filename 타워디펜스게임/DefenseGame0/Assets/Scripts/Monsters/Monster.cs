using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public GameObject hpBarPrefab; // HP 바 프리팹
    private GameObject hpBarInstance; // 생성된 HP 바 인스턴스



    private void Start()
    {
        CreateHPBar();
    }

    void CreateHPBar()
    {
        // Canvas를 찾아서 HP 바를 추가
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            // HP 바 프리팹을 Canvas 아래에 생성
            hpBarInstance = Instantiate(hpBarPrefab, canvas.transform);

            // 체력바와 몬스터 연결
            Slider hpSlider = hpBarInstance.GetComponentInChildren<Slider>();

            // MonsterStat을 가져와 공통 로직 처리
            MonsterStat monsterStat = GetComponent<MonsterStat>();

            if (monsterStat != null && hpSlider != null)
            {
                //Debug.Log("연결됨");
                monsterStat.SetHPBar(hpSlider); // 체력바 연결
            }
            else
            {
                Debug.LogError("MonsterStat 또는 Slider가 null입니다!"); 
            }
            // HP 바를 몬스터 위에 배치
            hpBarInstance.GetComponent<HPBar>().SetTarget(this.transform);

        }
    }



}
