using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1Anime : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>(); // animator 변수를 Player의 Animator 속성으로 초기화
    }

    public void StartAttackCreation()
    {
        if (!IsInvoking("StartAttack")) // 중복 호출 방지
        {
            InvokeRepeating("StartAttack", 1f, 2f); // 2초 간격으로 반복
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
