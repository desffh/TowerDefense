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

    // Cost ��ũ��Ʈ
    private Cost totalcost;

    private void Start()
    {
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        
            GetComponent<Button>().onClick.AddListener(BuyUnit);




    }

    // ���� ����
    private void BuyUnit()
    {
        if (totalcost != null)
        {
            gameManager.BuyUnit(unitObject, unitSprite);
            
            totalcost.cost -= costco;
        }
        else
        {
            Debug.Log("totalcost null");
        }    

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
