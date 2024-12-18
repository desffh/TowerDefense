using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // 스폰위치 배열 

    public GameObject Monster;

    private void Start()
    {
        // SpawnMonster함수를 2초후에 5초마다 실행
        InvokeRepeating("SpawnMonster", 2, 5);
    }

    // 스폰 랜덤 위치 몬스터 생성
    void SpawnMonster()
    {
        int ran = Random.Range(0, spawnPoints.Length);
        GameObject myMonster = 
            Instantiate(Monster, spawnPoints[ran].position, Quaternion.identity);

        myMonster.transform.SetParent(spawnPoints[ran]);

        // 목적지 설정
        var spawnPointComponent = spawnPoints[ran].GetComponent<SpawnPoint>();

        if (spawnPointComponent != null)
        {
            myMonster.GetComponent<MonsterController>().FinalDestination = spawnPointComponent.Destination;
        }
        else
        {
            Debug.LogError("SpawnPoint 컴포넌트를 찾을 수 없습니다.");
        }
    }
}
