using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit1Arrow : MonoBehaviour
{
    

    public GameObject arrow;

    public Transform pos;

    public bool hasArrow = false;



    public void StartArrowCreation()
    {
        if (!IsInvoking("ArrowCreate")) // �ߺ� ȣ�� ����
        {
            InvokeRepeating("ArrowCreate", 1f, 2f); // 2�� �������� �ݺ�
        }
    }

    public void StopArrowCreation()
    {
        if (IsInvoking("ArrowCreate"))
        {
            CancelInvoke("ArrowCreate"); // �ݺ� �ߴ�
        }
    }

    public void ArrowCreate()
    {
        if (!hasArrow)
        {
            Debug.Log("Ȱ ����");

            GameObject newArrow = Instantiate(arrow, pos.position, transform.rotation);

            hasArrow = true;

            // ������ ȭ�쿡 Destroy �̺�Ʈ ����
            Arrow unit1Arrow = newArrow.GetComponent<Arrow>();

            unit1Arrow.onDestroyed += ArrowDestroyed;

        }
    }

    private void ArrowDestroyed()
    {
        Debug.Log("Ȱ �ı�, hasArrow �ʱ�ȭ");
        hasArrow = false; // ȭ���� �ı��� �� �ٽ� ���� �����ϵ��� ����
    }
}
