using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


// 부모 추상 클래스 UnitStat

// 객체를 만들 수 없음
public abstract class UnitStat : MonoBehaviour
{
    [SerializeField] protected int maxHealth;       // 최대 체력

    [SerializeField] protected int currentHealth;   // 현재 체력

    protected Slider HPslider;                      // 체력 슬라이더

    protected Animator animator;                   // 애니메이터 추가
    private bool isDying = false;                  // 죽음 상태 플래그

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();       // Animator 컴포넌트 가져오기

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
        if (isDying) return; // 죽음 중일 때 추가 데미지 방지

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


    // 죽음 애니메이션 실행
    protected virtual void PlayDeathAnimation()
    {
        if (animator != null)
        {
            isDying = true;
            animator.SetTrigger("Die"); // Die 트리거 설정
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            Die(); // 애니메이터가 없으면 바로 Die 호출
        }
    }

    protected virtual void Die()
    {
        MonsterCount.Instance.DecreaseCount(); // 몬스터 카운트 감소
        Debug.Log($"{gameObject.name} 사망!");
        Destroy(gameObject);
        HPslider.gameObject.SetActive(false);
    }

    private IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(1.5f); // 애니메이션 지속 시간
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


    // 공격(가상함수) -> 자식에서 재정의 가능
    public virtual void Attack()
    {
        Debug.Log("유닛의 공격");
    }
}
