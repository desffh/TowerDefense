using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject currentUnit;

    public Sprite currentUnitSprite;

    public Transform tiles;

    public LayerMask tileMask;

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
            
            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasUnits)
            {
                Instantiate(currentUnit,
                    hit.collider.transform.position, Quaternion.identity);

                hit.collider.GetComponent<Tile>().hasUnits = true;
                
                currentUnit = null;
                currentUnitSprite = null;
            
            }
        }

    }
}
