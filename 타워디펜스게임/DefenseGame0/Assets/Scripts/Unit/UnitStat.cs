using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// �θ� �߻� Ŭ���� UnitStat

// ��ü�� ���� �� ����
public abstract class UnitStat : MonoBehaviour
{
    // �������� protected
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

    // ���ݹ��� attackRange

    // ������

    // �̸�, HP, �ڽ�Ʈ, ����, ���ݼӵ�, �̵��ӵ�
    public UnitStat(string name, int health, int cost, int defense, int attackSpeed, int moveSpeed)
    {
        this.name = name;
        this.health = health;
        this.cost = cost;
        this.defense = defense;
        this.moveSpeed = moveSpeed;
    }

    // ����(�����Լ�) -> �ڽĿ��� ������ ����
    public virtual void Attack()
    {
        Debug.Log("Attack");
    }
}
