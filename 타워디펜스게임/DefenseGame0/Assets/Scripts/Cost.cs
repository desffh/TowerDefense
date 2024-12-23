using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    [SerializeField] Text totalcost;

    [SerializeField]  TextMeshProUGUI totalCostText;


    // 정적 변수 : 전체 코스트
     static public int totalCost = 0;


    // 3초마다 cost 5씩 증가
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
        totalCost = 0; // 초기화
        StartCoroutine(AddCost());
    }

    public void UpdateUI()
    {
        totalCostText.text = totalCost.ToString();
    }

}
