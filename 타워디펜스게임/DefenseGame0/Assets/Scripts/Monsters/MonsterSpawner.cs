using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // ������ġ �迭 

    public GameObject Monster;

    private void Start()
    {
        // SpawnMonster�Լ��� 2���Ŀ� 5�ʸ��� ����
        InvokeRepeating("SpawnMonster", 2, 5);
    }

    // ���� ���� ��ġ ���� ����
    void SpawnMonster()
    {
        int ran = Random.Range(0, spawnPoints.Length);
        GameObject myMonster = 
            Instantiate(Monster, spawnPoints[ran].position, Quaternion.identity);
    }
}
