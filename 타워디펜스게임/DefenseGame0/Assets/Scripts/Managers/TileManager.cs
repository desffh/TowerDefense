using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class TileManager : MonoBehaviour
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

    // 숨겨둔 저장 타일 위치
    [SerializeField] Transform saveTile;

    private void Start()
    {
        unitCounting = gameObject.AddComponent<UnitCount>();
    }

    public void BuyUnit(GameObject unitPrefab, Sprite sprite)
    {
        // 유닛을 구매할 때만 Instantiate 호출
        if (currentUnit == null)
        {
            currentUnit = Instantiate(unitPrefab, saveTile.position, Quaternion.identity);
            currentUnit.SetActive(false); // 구매 후 대기 상태
        }

        currentUnitSprite = sprite; // 스프라이트 설정
        currentUnit.SetActive(true); // 유닛 활성화
    }

    public bool UnitOver()
    {
        // 유닛의 갯수가 한계 갯수와 같아지면 더이상 생성불가
        if (unitCount.GetUnitTotalCount() == unitCount.GetUnitCount())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 코루틴 사용해서 버튼이 1초뒤에 활성화되게
    IEnumerator UnitButtonActive()
    {
        yield return new WaitForSeconds(1.0f);

        // 유닛 목록 버튼 활성화
        foreach (Button button in unitButtons)
        {
            button.interactable = true;
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
            // 유닛이 꽉 차면 버튼 비활성화
            if (UnitOver() == true)
            {
                foreach (Button button in unitButtons)
                {
                    button.interactable = false;
                }
                return;
            }

            // 삭제존 클릭 시
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == LayerMask.NameToLayer("DeleteZone"))
            {
                Debug.Log("Delete Unit");
                currentUnit.transform.position = saveTile.position; // 세이브존으로 이동
                currentUnit.SetActive(false); // 유닛 비활성화
                currentUnitSprite = null;
                currentUnit = null;

                StartCoroutine(UnitButtonActive());
                return;
            }

            // 유닛 스프라이트 활성화
            if (currentUnitSprite != null)
            {
                hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;
            }

            // 메세지 활성화        
            SettingText.gameObject.SetActive(true);

            // 타일 마우스로 클릭 시
            if (Input.GetMouseButtonDown(0))
            {
                // 유닛이 없으면 생성 
                if (!hit.collider.GetComponent<Tile>().hasUnits)
                {
                    Tile tile = hit.collider.GetComponent<Tile>();

                    currentUnit.transform.position = hit.collider.transform.position; // 타일로 이동
                    tile.PlaceUnit(currentUnit, currentUnitSprite); // 타일에 유닛 저장

                    unitCount.Counting(); // 유닛 카운트 증가

                    if (tile.hasUnits == true)
                    {
                        SettingText.gameObject.SetActive(false); // 메시지 비활성화
                    }

                    currentUnit = null;
                    currentUnitSprite = null;

                    StartCoroutine(UnitButtonActive());
                }
            }
        }

        // 타일에 유닛이 있고, 클릭했고, 스프라이트 없을 때
        if (hit.collider != null && hit.collider.GetComponent<Tile>() != null
            && hit.collider.GetComponent<Tile>().hasUnits && currentUnitSprite == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Tile tile = hit.collider.GetComponent<Tile>();

                if (tile.placedUnit != null)
                {
                    currentUnit = tile.GetplacedUnit(); // 타일에서 유닛 가져오기
                    currentUnitSprite = tile.GetplacedUnitSprite();

                    tile.PlaceUnit(null, null); // 타일에서 유닛 제거
                    currentUnit.transform.position = saveTile.position; // 세이브존으로 이동
                }
            }
        }
    }
}

