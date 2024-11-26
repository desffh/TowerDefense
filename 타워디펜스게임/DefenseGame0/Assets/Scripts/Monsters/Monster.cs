using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;

    public GameObject hpBarPrefab; // HP 바 프리팹
    private GameObject hpBarInstance; // 생성된 HP 바 인스턴스

    private void Start()
    {
        CreateHPBar();
    }

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
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
