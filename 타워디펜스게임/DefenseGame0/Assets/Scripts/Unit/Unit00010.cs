using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ӹ��� �ڽ� Ŭ����
public class Unit00010 : UnitStat
{
    

    // base : �θ� Ŭ������ ������ ȣ��
    public Unit00010() : base("���� ��� ��ġ", 50, 3, 0, 3, 0)
    {
        
    }

    public override void Attack()
    {
        Debug.Log("00010 Attack");
    }

    

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireCube(transform.position - new Vector3(0, 7.5f, 0), new Vector2(13, 4));
    // }


    //public Transform Pos;
    //private Vector2 BoxSize = new Vector2(1, 1);
    //
    //void Start()
    //{
    //    Pos.position = new Vector2(0, 0);
    //}
    //
    //
    //void Update()
    //{
    //    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Pos.position, BoxSize, 0);
    //
    //    foreach (Collider2D collider in collider2Ds)
    //    {
    //        if (collider.name == "Enemy")
    //            Debug.Log("�浹");
    //    }
    //}

}
