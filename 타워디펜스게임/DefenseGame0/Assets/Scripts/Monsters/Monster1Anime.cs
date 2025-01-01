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
        if (animator != null)
        {
            animator.SetBool("Attack", true); // Attack 애니메이션으로 전환
        }
        else
        {
            Debug.LogError("Animator가 존재하지 않습니다!");
        }
    }

    public void EndAttack()
    {
        if (animator != null)
        {
            animator.SetBool("Attack", false); // Idle 애니메이션으로 전환
        }
        else
        {
            Debug.LogError("Animator가 존재하지 않습니다!");
        }
    }

}
