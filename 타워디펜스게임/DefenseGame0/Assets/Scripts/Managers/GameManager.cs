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


        // Ray와 충돌한 오브젝트가 현재 유닛이면

        // 콜라이더와 유닛이 충돌한다면
        if (hit.collider && currentUnit)
        {

            //  현재 유닛의 Sprite가져오고 컴포넌트 활성화
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            // 메세지 활성화        
            SettingText.gameObject.SetActive(true);

            // 마우스로 눌렀고, Ray와 충돌한 오브젝트의 타일이 hasUnit이 아니라면           
            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().hasUnits)
            {

                Debug.Log("MouseButtonDown");

                // 객체 생성
                GameObject unitPoint = Instantiate(currentUnit,
                    hit.collider.transform.position, Quaternion.identity);

                // Hierarchy창 GameManager자식으로 넣어주기 
                unitPoint.transform.SetParent(this.transform, false);

                // 충돌된 오브젝트가 있는 자리는 hasUnit = True
                hit.collider.GetComponent<Tile>().hasUnits = true;


                // 자리에 배치가 되었다면 메세지 비활성화
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
