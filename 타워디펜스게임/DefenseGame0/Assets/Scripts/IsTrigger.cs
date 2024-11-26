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
        monster.transform.position -= new Vector3(0, 0, 0);
    }
}
