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
