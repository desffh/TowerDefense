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

    [SerializeField] Transform canvas; // UI를 표시할 캔버스

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

        // 반복문으로 타일 가져오고 비활성화
        foreach(Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }

        // 콜라이더와 유닛이 충돌한다면
        if(hit.collider && currentUnit)
        {

            // Sprite가져오고 컴포넌트 활성화
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
