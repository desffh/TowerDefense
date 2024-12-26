using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit00050 : UnitStat
{
    //new private string name = "Å¬·Ð ½Ã»þ";

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
        Debug.Log("00050À¯´Ö Attack");
    }


    public Unit00050()
    {
        cost = 10;
        health = 50;
        defense = 0;
        damage = 30;
        attackspeed = 5;
        movespeed = 0;
    }
}
