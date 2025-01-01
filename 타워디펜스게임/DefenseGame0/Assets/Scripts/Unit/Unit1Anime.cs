using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1Anime : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>(); // animator ������ Player�� Animator �Ӽ����� �ʱ�ȭ
    }

    public void StartAttackCreation()
    {
        if (!IsInvoking("StartAttack")) // �ߺ� ȣ�� ����
        {
            InvokeRepeating("StartAttack", 1f, 2f); // 2�� �������� �ݺ�
        }
    }

    public void StartAttack()
    {
        animator.SetBool("Attack", true);
    }

    public void EndAttack()
    {
        animator.SetBool("Attack", false);
    }
}
