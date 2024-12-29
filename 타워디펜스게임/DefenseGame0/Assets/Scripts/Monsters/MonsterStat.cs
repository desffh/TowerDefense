using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;


public abstract class MonsterStat : MonoBehaviour
{
    [SerializeField] protected int maxHealth;       // �ִ� ü��

    [SerializeField] protected int currentHealth;   // ���� ü��

    protected Slider HPslider;                      // ü�� �����̴�

    protected virtual void Start()
    {
        currentHealth = maxHealth;

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
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (HPslider != null)
        {
            HPslider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        MonsterCount.Instance.DecreaseCount(); // ���� ī��Ʈ ����
        Debug.Log($"{gameObject.name} ���!");
        Destroy(gameObject);
        HPslider.gameObject.SetActive( false );
    }
    public abstract int Health
    { get;}

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
        Debug.Log("������ ����");
    }
}
