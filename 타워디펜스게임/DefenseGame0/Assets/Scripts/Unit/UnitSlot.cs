using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitSlot : MonoBehaviour
{


    public Sprite unitSprite; // 유닛 이미지

    public GameObject unitObject; // 유닛 객체

    public Image icon; // 유닛 이미지

    public int costco;

    public TextMeshProUGUI costText;

    // GameManager 스크립트
    private TileManager tileManager;

    // UnitStat 스크립트
    private UnitStat unitStat;

    private Cost Cost;

    private void Start()
    {
        tileManager =
            GameObject.Find("TileManager").GetComponent<TileManager>();
        
            GetComponent<Button>().onClick.AddListener(BuyUnit);

    }

    // 유닛 구매
    private void BuyUnit()
    {
        // totalcost > Unit.cost 일때만 실행
        if (costco <= Cost.totalCost)
        {
            
            tileManager.BuyUnit(unitObject, unitSprite);

            // 전체 cost에서 각각의 유닛 차감
            Cost.totalCost -= costco;

            // Hierarchy창에서 Total_Cost_Text 오브젝트 찾아서 코스트 갱신
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
        

        if(unitSprite) // Sprite가 있다면
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
