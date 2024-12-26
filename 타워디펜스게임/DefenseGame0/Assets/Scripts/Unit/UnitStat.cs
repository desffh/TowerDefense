using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// �θ� �߻� Ŭ���� UnitStat

// ��ü�� ���� �� ����
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


    // ����(�����Լ�) -> �ڽĿ��� ������ ����
    public virtual void Attack()
    {
        Debug.Log("������ ����");
    }
}
