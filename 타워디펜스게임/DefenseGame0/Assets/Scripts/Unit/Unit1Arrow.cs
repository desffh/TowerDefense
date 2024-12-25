using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1Arrow : MonoBehaviour
{
    // 활 프리팹
    private GameObject unit1arrow;

    GameObject bowObj;

    private void Start()
    {
        Vector3 pos = transform.position;

        bowObj = Instantiate(unit1arrow, pos, Quaternion.identity);

        bowObj.transform.SetParent(transform);//활의 부모로 플레이어 캐릭터를 설정
    }
}
