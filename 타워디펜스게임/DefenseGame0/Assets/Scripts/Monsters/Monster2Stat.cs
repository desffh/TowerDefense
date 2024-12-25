using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 프로즌 스티퍼 (일반형)
public class Monster2Stat : MonsterStat
{
    private int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    // get : 데이터를 반환해서 보여줌
    // set : 값을 설정하는 역할
    protected override int Health
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


    protected override void Attack()
    {
        Debug.Log("몬스터2의 공격");
    }


    public Monster2Stat()
    {
        health = 150;
        defense = 0;
        damage = 2;
        attackspeed = 5.0f;
        movespeed = 0.0f;
    }
}
