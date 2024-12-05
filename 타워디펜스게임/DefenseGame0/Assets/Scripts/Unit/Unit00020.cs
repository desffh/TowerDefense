using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit00020 : UnitStat
{
    public Unit00020() : base("소형 대포", 30, 5, 0,2, 0)
    {

    }

    public override void Attack()
    {
        Debug.Log("00020 Attack");
    }
}
