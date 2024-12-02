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

        myMonster.transform.SetParent(spawnPoints[ran]);

        // ������ ����
        var spawnPointComponent = spawnPoints[ran].GetComponent<SpawnPoint>();

        if (spawnPointComponent != null)
        {
            myMonster.GetComponent<MonsterController>().FinalDestination = spawnPointComponent.Destination;
        }
        else
        {
            Debug.LogError("SpawnPoint ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }
}
