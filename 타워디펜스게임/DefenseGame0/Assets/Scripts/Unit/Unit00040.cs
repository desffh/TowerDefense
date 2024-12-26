using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit00040 : UnitStat
{
   // new private string name = "클론 시프";

    private int cost;

    private int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    protected override int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public override int Health
    {
        get { return health; }
        set { health = value; }
    }

    protected override int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    protected override int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    protected override float AttackSpeed
    {
        get { return attackspeed; }
        set { attackspeed = value; }
    }
    protected override float MoveSpeed
    {
        get { return movespeed; }
        set { movespeed = value; }
    }


    public override void Attack()
    {
        Debug.Log("00040유닛 Attack");
    }


    public Unit00040()
    {
        cost = 7;
        health = 30;
        defense = 0;
        damage = 10;
        attackspeed = 3;
        movespeed = 0;
    }
}
