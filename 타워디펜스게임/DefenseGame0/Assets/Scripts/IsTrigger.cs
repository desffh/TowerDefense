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
        monster.transform.position -= new Vector3(0, 0, 0);
    }
}
