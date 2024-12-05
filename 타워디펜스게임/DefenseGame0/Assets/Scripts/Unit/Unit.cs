using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject hpBarPrefab; // HP �� ������
    private GameObject hpBarInstance; // ������ HP �� �ν��Ͻ�

    private void Start()
    {
        CreateHPBar();
    }

    void CreateHPBar()
    {
        // Canvas�� ã�Ƽ� HP �ٸ� �߰�
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            // HP �� �������� Canvas �Ʒ��� ����
            hpBarInstance = Instantiate(hpBarPrefab, canvas.transform);

            // HP �ٸ� ���� ���� ��ġ
            hpBarInstance.GetComponent<HPBar>().SetTarget(this.transform);
        }
    }
}
