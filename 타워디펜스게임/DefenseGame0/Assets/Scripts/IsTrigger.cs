using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�ϸ� ���Ͱ� �������� �ʰ�

        Monster monster = collision.gameObject.GetComponent<Monster>();


        Unit unit = collision.gameObject.GetComponent<Unit>();

        Debug.Log("Collider");
        
        // ���Ϳ� �浹�ϸ� ����
        if (monster != null)
        {
            monster.speed = 0;
            transform.position -= new Vector3(monster.speed, 0, 0);
        }

    }
}
