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

  

}
