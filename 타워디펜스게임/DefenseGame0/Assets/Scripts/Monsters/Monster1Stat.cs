using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 쿠션더미(일반형)
public class Monster1Stat : MonsterStat
{
    
    private int defense;

    private int damage;

    private float attackspeed;

    private float movespeed;

    protected override void Start()
    {
        maxHealth = 50;
        base.Start(); // 부모 클래스의 Start 호출

    }
    // 애니메이션 이벤트에서 호출
    protected override void Die()
    {
        base.Die(); // 기본 Die 동작 실행
    }

    // get : 데이터를 반환해서 보여줌


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
        Debug.Log("몬스터1의 공격");
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
    
