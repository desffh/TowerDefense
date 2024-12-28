using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ��Ǵ���(�Ϲ���)
public class Monster1Stat : MonsterStat
{
    

    private int health;

    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    protected override void Start()
    {
        maxHealth = 50;
        base.Start(); // �θ� Ŭ������ Start ȣ��

    }

    // get : �����͸� ��ȯ�ؼ� ������
    // set : ���� �����ϴ� ����
    public override int Health
    {
        get { return health; }
   
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
        //maxhealth = 50;
        defense = 0;
        damage = 1;
        attackspeed = 3.0f;
        movespeed = 0.5f;
    }
}
    
