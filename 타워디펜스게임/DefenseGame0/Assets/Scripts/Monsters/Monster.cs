using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
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

            // ü�¹ٿ� ���� ����
            Slider hpSlider = hpBarInstance.GetComponentInChildren<Slider>();

            // MonsterStat�� ������ ���� ���� ó��
            MonsterStat monsterStat = GetComponent<MonsterStat>();

            if (monsterStat != null && hpSlider != null)
            {
                //Debug.Log("�����");
                monsterStat.SetHPBar(hpSlider); // ü�¹� ����
            }
            else
            {
                Debug.LogError("MonsterStat �Ǵ� Slider�� null�Դϴ�!"); 
            }
            // HP �ٸ� ���� ���� ��ġ
            hpBarInstance.GetComponent<HPBar>().SetTarget(this.transform);

        }
    }



}
