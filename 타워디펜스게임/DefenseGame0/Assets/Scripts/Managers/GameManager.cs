using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject currentUnit;

    public Sprite currentUnitSprite;

    public Transform tiles;

    public LayerMask tileMask;

    public LayerMask DeleteZone;

    public GameObject Deletezone;
   
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
        int mask = tileMask | DeleteZone;
    
        RaycastHit2D hit =
        Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), 
        Vector2.zero, Mathf.Infinity, mask);
    
        // �ݺ������� Ÿ�� �������� ��Ȱ��ȭ
        foreach(Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }
    
    
        // Ray�� �浹�� ������Ʈ�� ���� �����̸�
    
        // �ݶ��̴��� ������ �浹�Ѵٸ�
        if (hit.collider && currentUnit)
        {
            //  currentUnit�� null�� �ƴϾ�� ����
            if (currentUnitSprite != null)
            {
                //  ���� ������ Sprite�������� ������Ʈ Ȱ��ȭ
                hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            }
            // �޼��� Ȱ��ȭ        
            SettingText.gameObject.SetActive(true);
    
    
            if(Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == LayerMask.NameToLayer("DeleteZone"))
            {
                Debug.Log("delete");

                // currentUnitSprite�� null�� �����Ͽ� ���� ����
                currentUnit = null;

                currentUnitSprite = null;

                return;
            }
    
    
            // ���콺�� ������, Ray�� �浹�� ������Ʈ�� Ÿ���� hasUnit�� �ƴ϶��           
            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasUnits)
            {
            
                Debug.Log("MouseButtonDown");
            
                // ��ü ����
                GameObject unitPoint = Instantiate(currentUnit,
                    hit.collider.transform.position, Quaternion.identity);
            
                // Hierarchyâ GameManager�ڽ����� �־��ֱ� 
                unitPoint.transform.SetParent(this.transform, false);
            
                // �浹�� ������Ʈ�� �ִ� �ڸ��� hasUnit = True
                hit.collider.GetComponent<Tile>().hasUnits = true;
            
            
                // �ڸ��� ��ġ�� �Ǿ��ٸ� �޼��� ��Ȱ��ȭ
                if (hit.collider.GetComponent<Tile>().hasUnits == true)
                {
                    SettingText.gameObject.SetActive(false);
                }
            
            
                currentUnit = null;
                currentUnitSprite = null;
            }
        }
    
    }


}
