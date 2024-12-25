using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̽��Ǿ� (�Ϲ���)
public class Monster3Stat : MonsterStat
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
        Debug.Log("����3�� ����");
    }


    public Monster3Stat()
    {
        health = 50;
        defense = 0;
        damage = 5;
        attackspeed = 2.0f;
        movespeed = 2.0f;
    }
}
