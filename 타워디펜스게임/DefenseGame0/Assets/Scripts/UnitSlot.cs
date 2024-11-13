using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitSlot : MonoBehaviour
{
    public Sprite unitSprite; // 유닛 이미지

    public GameObject unitObject; // 유닛 객체

    public int cost;

    public Image icon; // 유닛 이미지

    public TextMeshProUGUI costText;

    // GameManager 스크립트
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
        if(unitSprite) // Sprite가 있다면
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
