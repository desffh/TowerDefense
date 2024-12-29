using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Anime : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>(); // animator 변수를 Player의 Animator 속성으로 초기화
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
