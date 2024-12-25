using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // ������ġ �迭 

    //public GameObject Monster;


    [SerializeField] GameObject level1Monster;
    [SerializeField] GameObject level2Monster;
    [SerializeField] GameObject bossMonster;


    // ���͸� �������� ������ ť
    Queue<GameObject> monsterQueue = new Queue<GameObject>();

    private void Awake()
    {
        // level 1 ���� 5��
        for(int i = 0; i < 5; i++)
        {
            monsterQueue.Enqueue(level1Monster);
        }
        // level 2 ���� 4��
        for(int i = 0; i < 4; i++)
        {
            monsterQueue.Enqueue(level2Monster);
        }
        // ���� ���� 1��
        monsterQueue.Enqueue(bossMonster);
    }

    private void Start()
    {
        // SpawnMonster�Լ��� 2���Ŀ� 5�ʸ��� ����
        InvokeRepeating("SpawnMonster", 2, 5);
    }

    // ���� ���� ��ġ ���� ����
    void SpawnMonster()
    {
        int ran = Random.Range(0, spawnPoints.Length);

        if(monsterQueue.Count != 0)
        {
            // ť���� �ϳ��� ����
            GameObject monsterSpawn = monsterQueue.Dequeue();
            
            GameObject myMonster =
                Instantiate(monsterSpawn, spawnPoints[ran].position, Quaternion.identity);
            
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
}
