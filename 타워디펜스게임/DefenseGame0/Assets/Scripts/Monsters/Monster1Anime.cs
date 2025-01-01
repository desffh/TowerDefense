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
        if (animator != null)
        {
            animator.SetBool("Attack", true); // Attack �ִϸ��̼����� ��ȯ
        }
        else
        {
            Debug.LogError("Animator�� �������� �ʽ��ϴ�!");
        }
    }

    public void EndAttack()
    {
        if (animator != null)
        {
            animator.SetBool("Attack", false); // Idle �ִϸ��̼����� ��ȯ
        }
        else
        {
            Debug.LogError("Animator�� �������� �ʽ��ϴ�!");
        }
    }

}
