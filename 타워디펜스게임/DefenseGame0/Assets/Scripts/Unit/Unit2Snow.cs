using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2Snow : MonoBehaviour
{
    public GameObject snow;

    public Transform pos;

    public bool hasSnow = false;

    public void ActiveFalse()
    {
        hasSnow = false;
    }


    public void StartSnowCreation()
    {
        if (!IsInvoking("SnowCreate")) // �ߺ� ȣ�� ����
        {
            InvokeRepeating("SnowCreate", 1f, 2f); // 2�� �������� �ݺ�
        }
    }

    public void StopSnowCreation()
    {
        if (IsInvoking("SnowCreate"))
        {
            CancelInvoke("SnowCreate"); // �ݺ� �ߴ�
        }
    }

    public void SnowCreate()
    {
        if (!hasSnow)
        {
            Debug.Log("�� ����");

            GameObject newSnow = Instantiate(snow, pos.position, transform.rotation);

            // ������ ȭ���� ������ �ڽ����� ����
            newSnow.transform.parent = this.transform;

            hasSnow = true;

            // ������ ȭ�쿡 Destroy �̺�Ʈ ����
            Snow unit2snow = newSnow.GetComponent<Snow>();

            if (unit2snow != null)
            {
                unit2snow.onDestroyed += SnowDestroyed;
            }

        }
    }

    private void SnowDestroyed()
    {
        Debug.Log("�� �ı�, hasSnow �ʱ�ȭ");
        hasSnow = false; // ���� �ı��� �� �ٽ� ���� �����ϵ��� ����
    }
}
