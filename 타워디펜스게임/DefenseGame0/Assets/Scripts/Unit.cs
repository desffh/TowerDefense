using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Canvas를 찾아서 HP 바를 추가
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            // HP 바 프리팹을 Canvas 아래에 생성
            hpBarInstance = Instantiate(hpBarPrefab, canvas.transform);

            // HP 바를 몬스터 위에 배치
            hpBarInstance.GetComponent<HPBar>().SetTarget(this.transform);
        }
    }
}
