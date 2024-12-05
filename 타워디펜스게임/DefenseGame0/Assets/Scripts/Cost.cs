using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    [SerializeField] Text totalcost;

    [SerializeField] TextMeshProUGUI totalCostText;

     public int cost;


    private void Start()
    {
        StartCoroutine(AddCost());
    }


    // 3초마다 cost 5씩 증가
    IEnumerator AddCost()
    {
        while (cost < 50)
        {
            yield return new WaitForSeconds(3.0f);

            cost += 5;
            UpdateUI();
            Debug.Log(cost);
        }
    }

    public void UpdateUI()
    {
        totalCostText.text = cost.ToString();
    }

}
