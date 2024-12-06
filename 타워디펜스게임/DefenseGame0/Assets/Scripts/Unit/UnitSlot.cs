using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitSlot : MonoBehaviour
{


    public Sprite unitSprite; // ���� �̹���

    public GameObject unitObject; // ���� ��ü

    public Image icon; // ���� �̹���

    public int costco;

    public TextMeshProUGUI costText;

    // GameManager ��ũ��Ʈ
    private GameManager gameManager;

    // UnitStat ��ũ��Ʈ
    private UnitStat unitStat;

    private Cost Cost;




    private void Start()
    {
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        
        GetComponent<Button>().onClick.AddListener(BuyUnit);


    }

    // ���� ����
    private void BuyUnit()
    {
        // totalcost > Unit.cost �϶��� ����
        if (costco < Cost.totalCost)
        {
            gameManager.BuyUnit(unitObject, unitSprite);
            // ��ü cost���� ������ ���� ����
            Cost.totalCost -= costco;

        }
        else
        {
            Debug.Log("No Create");
        }
            

        
        // Hierarchyâ���� Total_Cost_Text ������Ʈ ã�Ƽ� �ڽ�Ʈ ����
        GameObject.Find("Total_Cost_Text").GetComponent<TextMeshProUGUI>().text =
        Cost.totalCost.ToString();
            

        Debug.Log(Cost.totalCost);

    }

    public void OnValidate()
    {
        if(unitSprite) // Sprite�� �ִٸ�
        {
            icon.enabled = true;
            icon.sprite = unitSprite;
            costText.text = costco.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }


    public void SetUnitStat(UnitStat unitStat)
    {
        this.unitStat = unitStat;
    }    

}
