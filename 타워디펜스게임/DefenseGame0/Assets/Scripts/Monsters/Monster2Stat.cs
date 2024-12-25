using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ ��Ƽ�� (�Ϲ���)
public class Monster2Stat : MonsterStat
{
    private int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    // get : �����͸� ��ȯ�ؼ� ������
    // set : ���� �����ϴ� ����
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
        Debug.Log("����2�� ����");
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
