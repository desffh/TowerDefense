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
    private TileManager tileManager;

    // UnitStat ��ũ��Ʈ
    private UnitStat unitStat;

    private Cost Cost;

    private void Start()
    {
        tileManager =
            GameObject.Find("TileManager").GetComponent<TileManager>();
        
            GetComponent<Button>().onClick.AddListener(BuyUnit);

    }

    // ���� ����
    private void BuyUnit()
    {
        // totalcost > Unit.cost �϶��� ����
        if (costco <= Cost.totalCost)
        {
            
            tileManager.BuyUnit(unitObject, unitSprite);

            // ��ü cost���� ������ ���� ����
            Cost.totalCost -= costco;

            // Hierarchyâ���� Total_Cost_Text ������Ʈ ã�Ƽ� �ڽ�Ʈ ����
            GameObject.Find("Total_Cost_Text").GetComponent<TextMeshProUGUI>().text =
            Cost.totalCost.ToString();

        }
        else
        {
            Debug.Log("No Create");
        }
      

        // Debug.Log(Cost.totalCost);

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
