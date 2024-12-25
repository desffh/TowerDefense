using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTile : MonoBehaviour
{
    MonsterController monsterController;

    private void Awake()
    {
        // 몬스터 컨트롤 스크립트 가져오기
        monsterController = GetComponent<MonsterController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NotMonsterTile"))
        {
            monsterController.isStopped = true;
            
            Debug.Log("몬스터가 낫타일과 충돌함");

        }
    }

}
