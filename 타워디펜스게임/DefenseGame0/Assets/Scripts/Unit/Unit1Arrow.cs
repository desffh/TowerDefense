using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1Arrow : MonoBehaviour
{
    // Ȱ ������
    private GameObject unit1arrow;

    GameObject bowObj;

    private void Start()
    {
        Vector3 pos = transform.position;

        bowObj = Instantiate(unit1arrow, pos, Quaternion.identity);

        bowObj.transform.SetParent(transform);//Ȱ�� �θ�� �÷��̾� ĳ���͸� ����
    }
}
