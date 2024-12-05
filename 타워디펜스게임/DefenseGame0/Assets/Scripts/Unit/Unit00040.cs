using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit00040 : UnitStat
{
    public Unit00040() : base("클론 시프", 30, 7, 0, 10, 0)
    {

    }

    public override void Attack()
    {
        Debug.Log("00040 Attack");
    }
}
