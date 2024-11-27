using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌하면 몬스터가 움직이지 않게

        Monster monster = collision.gameObject.GetComponent<Monster>();


        Unit unit = collision.gameObject.GetComponent<Unit>();

        Debug.Log("Collider");
        
        // 몬스터와 충돌하면 정지
        if (monster != null)
        {
            monster.speed = 0;
            transform.position -= new Vector3(monster.speed, 0, 0);
        }

    }
}
