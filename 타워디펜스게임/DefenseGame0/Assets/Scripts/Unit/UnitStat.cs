using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


// �θ� �߻� Ŭ���� UnitStat

// ��ü�� ���� �� ����
public abstract class UnitStat : MonoBehaviour
{
    [SerializeField] protected int maxHealth;       // �ִ� ü��

    [SerializeField] protected int currentHealth;   // ���� ü��

    protected Slider HPslider;                      // ü�� �����̴�

    protected Animator animator;                   // �ִϸ����� �߰�
    private bool isDying = false;                  // ���� ���� �÷���

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();       // Animator ������Ʈ ��������

        if (HPslider != null)
        {
            HPslider.maxValue = maxHealth;
            HPslider.value = currentHealth;
        }

        //Debug.Log($"MonsterStat �ʱ�ȭ: MaxHealth={maxHealth}, CurrentHealth={currentHealth}");
    }

    public void SetHPBar(Slider slider)
    {
        //Debug.Log("SetHPBar ȣ���");
        HPslider = slider;

        if (HPslider != null)
        {
            //Debug.Log($"�����̴� �ʱ�ȭ: MaxHealth={maxHealth}, CurrentHealth={currentHealth}");
            HPslider.maxValue = maxHealth;
            HPslider.value = currentHealth;
        }
        else
        {
            //Debug.LogError("�����̴��� null�Դϴ�!");
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDying) return; // ���� ���� �� �߰� ������ ����

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (HPslider != null)
        {
            HPslider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            PlayDeathAnimation();
        }
    }


    // ���� �ִϸ��̼� ����
    protected virtual void PlayDeathAnimation()
    {
        if (animator != null)
        {
            isDying = true;
            animator.SetTrigger("Die"); // Die Ʈ���� ����
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            Die(); // �ִϸ����Ͱ� ������ �ٷ� Die ȣ��
        }
    }

    protected virtual void Die()
    {
        MonsterCount.Instance.DecreaseCount(); // ���� ī��Ʈ ����
        Debug.Log($"{gameObject.name} ���!");
        Destroy(gameObject);
        HPslider.gameObject.SetActive(false);
    }

    private IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(1.5f); // �ִϸ��̼� ���� �ð�
        Die();
    }

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
