using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HPBar : MonoBehaviour
{
    public Transform monsterTransform; // ������ ��ġ

    private void Start()
    {

    }


    private void Update()
    { 

        // 1. ������ ���� ��ǥ�� �������� ����
        Vector3 adjustedWorldPosition = monsterTransform.position + new Vector3(0,1,0);

        // 2. ȭ�� ��ǥ�� ��ȯ
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(adjustedWorldPosition);

        // 3. HP ���� ȭ�� ��ǥ ����
        transform.position = screenPosition;
    }

        public void SetTarget(Transform newTarget)
        {
            monsterTransform = newTarget;
            //Debug.Log($"HPBar�� {monsterTransform.name} ���� �Ϸ�");
        }

}
