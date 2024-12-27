using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��Ǵ���(�Ϲ���)
public class Monster1Stat : MonsterStat
{
    [SerializeField] int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    // get : �����͸� ��ȯ�ؼ� ������
    // set : ���� �����ϴ� ����
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


    protected override void Attack()
    {
        Debug.Log("����1�� ����");
    }


    public Monster1Stat()
    {
        health = 50;
        defense = 0;
        damage = 1;
        attackspeed = 3.0f;
        movespeed = 0.5f;
    }
}
    
