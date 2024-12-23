using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    [SerializeField] Text totalcost;

    [SerializeField]  TextMeshProUGUI totalCostText;


    // ���� ���� : ��ü �ڽ�Ʈ
     static public int totalCost = 0;


    // 3�ʸ��� cost 5�� ����
    IEnumerator AddCost()
    {
        while (totalCost < 50)
        {
            yield return new WaitForSeconds(2.0f);

            totalCost += 5;
            UpdateUI();
            //Debug.Log(totalCost);
        }
    }

    private void Start()
    {
        totalCost = 0; // �ʱ�ȭ
        StartCoroutine(AddCost());
    }

    public void UpdateUI()
    {
        totalCostText.text = totalCost.ToString();
    }

}
