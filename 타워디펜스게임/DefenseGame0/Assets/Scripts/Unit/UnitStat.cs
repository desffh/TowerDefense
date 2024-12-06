using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// 부모 추상 클래스 UnitStat

// 객체를 만들 수 없음
public abstract class UnitStat : MonoBehaviour
{
    // 가져오고 protected
    public new string  name
    {
        get; protected set;
    }

    public int health
    {
        get; protected set;
    }

    public int cost
    {
        get; protected set;
    }

    public int defense
    {
        get; protected set;
    }

    public int attackSpeed
    {
        get; protected set;
    }

    public int moveSpeed
    {
        get; protected set;
    }

    // 공격범위 attackRange

    // 생성자

    // 이름, HP, 코스트, 방어력, 공격속도, 이동속도
    public UnitStat(string name, int health, int cost, int defense, int attackSpeed, int moveSpeed)
    {
        this.name = name;
        this.health = health;
        this.cost = cost;
        this.defense = defense;
        this.moveSpeed = moveSpeed;
    }

    // 공격(가상함수) -> 자식에서 재정의 가능
    public virtual void Attack()
    {
        Debug.Log("Attack");
    }
}
