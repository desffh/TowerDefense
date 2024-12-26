using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// 부모 추상 클래스 UnitStat

// 객체를 만들 수 없음
public abstract class UnitStat : MonoBehaviour
{
    protected abstract int Cost
    { get; set; }

    public abstract int Health
    { get; set; }

    protected abstract int Defense
    { get; set; }

    protected abstract int Damage
    { get; set; }

    protected abstract float AttackSpeed
    { get; set; }

    protected abstract float MoveSpeed
    { get; set; }


    // 공격(가상함수) -> 자식에서 재정의 가능
    public virtual void Attack()
    {
        Debug.Log("유닛의 공격");
    }
}
