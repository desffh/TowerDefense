using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTile : MonoBehaviour
{
    MonsterController monsterController;

    private void Awake()
    {
        // ���� ��Ʈ�� ��ũ��Ʈ ��������
        monsterController = GetComponent<MonsterController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NotMonsterTile"))
        {
            monsterController.isStopped = true;
            
            Debug.Log("���Ͱ� ��Ÿ�ϰ� �浹��");

        }
    }

}
