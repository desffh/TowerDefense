using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitSlot : MonoBehaviour
{
    public Sprite unitSprite; // ���� �̹���

    public GameObject unitObject; // ���� ��ü

    public int cost;

    public Image icon; // ���� �̹���

    public TextMeshProUGUI costText;

    // GameManager ��ũ��Ʈ
    private GameManager gameManager;

    private void Start()
    {
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManager>();
        
            GetComponent<Button>().onClick.AddListener(BuyUnit);
    }

    private void BuyUnit()
    {
        gameManager.BuyUnit(unitObject, unitSprite);
    }

    public void OnValidate()
    {
        if(unitSprite) // Sprite�� �ִٸ�
        {
            icon.enabled = true;
            icon.sprite = unitSprite;
            costText.text = cost.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }


}
