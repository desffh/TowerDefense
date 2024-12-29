using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;


public abstract class MonsterStat : MonoBehaviour
{
    [SerializeField] protected int maxHealth;       // 최대 체력

    [SerializeField] protected int currentHealth;   // 현재 체력

    protected Slider HPslider;                      // 체력 슬라이더

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        if (HPslider != null)
        {
            HPslider.maxValue = maxHealth;
            HPslider.value = currentHealth;
        }

        //Debug.Log($"MonsterStat 초기화: MaxHealth={maxHealth}, CurrentHealth={currentHealth}");
    }

    public void SetHPBar(Slider slider)
    {
        //Debug.Log("SetHPBar 호출됨");
        HPslider = slider;

        if (HPslider != null)
        {
            //Debug.Log($"슬라이더 초기화: MaxHealth={maxHealth}, CurrentHealth={currentHealth}");
            HPslider.maxValue = maxHealth;
            HPslider.value = currentHealth;
        }
        else
        {
            //Debug.LogError("슬라이더가 null입니다!");
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
        MonsterCount.Instance.DecreaseCount(); // 몬스터 카운트 감소
        Debug.Log($"{gameObject.name} 사망!");
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
        Debug.Log("몬스터의 공격");
    }
}
