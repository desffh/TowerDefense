using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 저장한 유닛정보
    public GameObject selectUnit;

    public Sprite selectUnitSprite;

    // 구입한 유닛정보
    public GameObject currentUnit;

    public Sprite currentUnitSprite;

    public Transform tiles;

    // 레이어
    public LayerMask tileMask;

    public LayerMask DeleteZone;

   // 삭제 존

    public GameObject Deletezone;
   

    [SerializeField] GameObject UnitPoint;

    [SerializeField] Text SettingText;

    [SerializeField] Transform canvas; // UI를 표시할 캔버스

    // 버튼 배열

    [SerializeField] Button[] unitButtons;

    private UnitCount unitCounting;

    // 배치된 유닛 리스트
    private List<int> units = new List<int>();


    [SerializeField] UnitCount unitCount;

    GameObject selectedUnit = null;
    Sprite selectedSprite = null;

    private void Start()
    {
        unitCounting = gameObject.AddComponent<UnitCount>();
    }


    public void BuyUnit(GameObject unit, Sprite sprite)
    {
        currentUnit = unit;
        currentUnitSprite = sprite;
    }

    
    public bool UnitOver()
    {
        // 유닛의 갯수가 한계 갯수와 같아지면 더이상 생성불가
        if (unitCount.GetUnitTotalCount() == unitCount.GetUnitCount())
        {
            
            return true;
        }
        else
            { return false; }

    }


    // 코루틴 사용해서 버튼이 1초뒤에 활성화되게
    IEnumerator UnitButtonActive()
    {
        yield return new WaitForSeconds(1.0f);

        // 유닛 목록 버튼 비활성화
        foreach (Button button in unitButtons)
        {
            button.interactable = true; // 버튼 클릭 활성화
            //Debug.Log("1초 뒤 코루틴 활성화");
        }
    }

    private void Update()
    {
        int mask = tileMask | DeleteZone;

        RaycastHit2D hit =
        Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
        Vector2.zero, Mathf.Infinity, mask);


        // 반복문으로 타일 가져오고 비활성화
        foreach (Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }



        // 마우스 콜라이더와 (유닛목록에서 구매한) 유닛이 충돌한다면
        if (hit.collider && currentUnit)
        {
            if (UnitOver() == true)
            {
                Debug.Log("UnitTotalCount: " + unitCount.GetUnitTotalCount());
                Debug.Log("UnitCount: " + unitCount.GetUnitCount());

                Debug.Log("UnitOver 성공");
                // 유닛 목록 버튼 비활성화
                foreach (Button button in unitButtons)
                {
                    button.interactable = false; // 버튼 클릭 비활성화
                    //Debug.Log("비활성화");
                }
                return;
            }

            // 유닛 목록 버튼 비활성화
            foreach (Button button in unitButtons)
            {
                button.interactable = false; // 버튼 클릭 비활성화
                //Debug.Log("비활성화");
            }

            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == LayerMask.NameToLayer("DeleteZone"))
            {
                Debug.Log("delete");

                // currentUnitSprite을 null로 설정하여 참조 해제
                currentUnit = null;

                currentUnitSprite = null;

                StartCoroutine(UnitButtonActive());

                return;
            }

            //  currentUnit이 null이 아니어야 실행 (활성화중일때만)
            if (currentUnitSprite != null)
            {
                //  현재 유닛의 Sprite가져오고 컴포넌트 활성화
                hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            }
            // 메세지 활성화        
            SettingText.gameObject.SetActive(true);

            // 마우스로 눌렀고, Ray와 충돌한 오브젝트의 타일이 hasUnit이 아니라면           
            if (Input.GetMouseButtonDown(0))
            {
                if (!hit.collider.GetComponent<Tile>().hasUnits)
                {
                    //Debug.Log("객체 생성");
                    // 객체 생성
                    GameObject unitPoint = Instantiate(currentUnit,
                        hit.collider.transform.position, Quaternion.identity);


                    // Hierarchy창 GameManager자식으로 생성된 객체 넣어주기 
                    unitPoint.transform.SetParent(this.transform, false);

                    // 충돌된 오브젝트의 Tile 스크립트 가져오기
                    Tile tile = hit.collider.GetComponent<Tile>();

                    if (tile != null)
                    {
                        // 유닛 정보 저장
                        tile.PlaceUnit(unitPoint, currentUnitSprite);
                    };

                    Debug.Log("유닛 카운팅");
                    unitCount.Counting();

                    // 자리에 배치가 되었다면 메세지 비활성화
                    if (hit.collider.GetComponent<Tile>().hasUnits == true)
                    {
                        SettingText.gameObject.SetActive(false);
                    }

                    currentUnit = null;
                    currentUnitSprite = null;

                    StartCoroutine(UnitButtonActive());
                }
            
                // 타일에 유닛이 있을 경우
                if (hit.collider.GetComponent<Tile>().hasUnits)
                {
                    Tile tile = hit.collider.GetComponent<Tile>();
                    
                
                    if (tile.placedUnit != null)
                    {
                        // 선택한 유닛 활성화 및 따라다니도록 설정
                        selectedUnit = tile.GetplacedUnit();
                        selectedSprite = tile.GetplacedUnitSprite();
                        tile.PlaceUnit(null,null); // 유닛 정보를 타일에서 제거
                        //tile.RemoveUnit();
                    }
                    // 타일에 유닛이 없고, 이미 선택된 유닛이 있을 경우
                    else if (tile.placedUnit != null)
                    {
                        // 유닛을 새 타일에 배치
                        //tile.PlaceUnit(selectedUnit, selectedSprite);
                        
                        tile.PlaceUnit(selectedUnit,selectedSprite); // 새 타일에 유닛 정보 저장
                        selectedUnit = null; // 선택 상태 해제
                    }
                
                }
            
            
            }


        }
    }

}
