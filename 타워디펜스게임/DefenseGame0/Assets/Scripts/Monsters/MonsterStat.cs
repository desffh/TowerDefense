using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterStat : MonoBehaviour
{
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

    protected virtual void Attack()
    {
        Debug.Log("몬스터의 공격");
    }
}
