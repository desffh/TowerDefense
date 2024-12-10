using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject currentUnit;

    public Sprite currentUnitSprite;

    public Transform tiles;

    public LayerMask tileMask;


    [SerializeField] GameObject UnitPoint;

    [SerializeField] Text SettingText;

    [SerializeField] Transform canvas; // UI�� ǥ���� ĵ����

    public void BuyUnit(GameObject unit, Sprite sprite)
    {
        currentUnit = unit;
        currentUnitSprite = sprite;
    }

    private void Update()
    {
        RaycastHit2D hit =
        Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), 
        Vector2.zero, Mathf.Infinity, tileMask);

        // �ݺ������� Ÿ�� �������� ��Ȱ��ȭ
        foreach(Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }

        // �ݶ��̴��� ������ �浹�Ѵٸ�
        if(hit.collider && currentUnit)
        {

            // Sprite�������� ������Ʈ Ȱ��ȭ
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            SettingText.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasUnits)
            {

                Debug.Log("MouseButtonDown");
                
                GameObject unitPoint = Instantiate(currentUnit,
                    hit.collider.transform.position, Quaternion.identity);

                unitPoint.transform.SetParent(this.transform, false);

                hit.collider.GetComponent<Tile>().hasUnits = true;

                if(hit.collider.GetComponent<Tile>().hasUnits == true)
                {
                    SettingText.gameObject.SetActive(false);    
                }
                
                currentUnit = null;
                currentUnitSprite = null;
            }
            
        }

    }
}
