using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Anime : MonoBehaviour
{
    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>(); // animator ������ Player�� Animator �Ӽ����� �ʱ�ȭ
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
