using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속받은 자식 클래스
public class Unit00010 : UnitStat
{
    

    // base : 부모 클래스의 생성자 호출
    public Unit00010() : base("간이 사격 장치", 50, 3, 0, 3, 0)
    {
        
    }

    public override void Attack()
    {
        Debug.Log("00010 Attack");
    }

  

}
