using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ӹ��� �ڽ� Ŭ����
public class Unit00010 : UnitStat
{
    //new private string name = "���� ��� ��ġ";

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
        Debug.Log("00010���� Attack");
    }

    
    public Unit00010()
    {
        cost = 3;
        health = 50;
        defense = 0;
        damage = 5;
        attackspeed = 3;
        movespeed = 0;
    }

}
