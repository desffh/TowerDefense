using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    // ������ ��������
    public GameObject selectUnit;

    public Sprite selectUnitSprite;

    // ������ ��������
    public GameObject currentUnit;

    public Sprite currentUnitSprite;

    public Transform tiles;

    // ���̾�
    public LayerMask tileMask;

    public LayerMask DeleteZone;

   // ���� ��

    public GameObject Deletezone;
   

    [SerializeField] GameObject UnitPoint;

    [SerializeField] Text SettingText;

    [SerializeField] Transform canvas; // UI�� ǥ���� ĵ����

    // ��ư �迭

    [SerializeField] Button[] unitButtons;

    private UnitCount unitCounting;

    // ��ġ�� ���� ����Ʈ
    private List<int> units = new List<int>();


    [SerializeField] UnitCount unitCount;


    // ���ܵ� ���� Ÿ�� ��ġ
    [SerializeField] Transform saveTile;


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
        // ������ ������ �Ѱ� ������ �������� ���̻� �����Ұ�
        if (unitCount.GetUnitTotalCount() == unitCount.GetUnitCount())
        {
            
            return true;
        }
        else
            { return false; }

    }


    // �ڷ�ƾ ����ؼ� ��ư�� 1�ʵڿ� Ȱ��ȭ�ǰ�
    IEnumerator UnitButtonActive()
    {
        yield return new WaitForSeconds(1.0f);

        // ���� ��� ��ư ��Ȱ��ȭ
        foreach (Button button in unitButtons)
        {
            button.interactable = true; // ��ư Ŭ�� Ȱ��ȭ
            //Debug.Log("1�� �� �ڷ�ƾ Ȱ��ȭ");
        }
    }

    private void Update()
    {
        int mask = tileMask | DeleteZone;

        RaycastHit2D hit =
        Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),
        Vector2.zero, Mathf.Infinity, mask);


        // �ݺ������� Ÿ�� �������� ��Ȱ��ȭ
        foreach (Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }



        // ���콺 �ݶ��̴��� (���ָ�Ͽ��� ������) ������ �浹�Ѵٸ�
        if (hit.collider && currentUnit)
        {
            // ������ ������ ��ư ��Ȱ��ȭ
            if (UnitOver() == true)
            {
                Debug.Log("UnitTotalCount: " + unitCount.GetUnitTotalCount());
                Debug.Log("UnitCount: " + unitCount.GetUnitCount());

                Debug.Log("UnitOver ����");
                // ���� ��� ��ư ��Ȱ��ȭ
                foreach (Button button in unitButtons)
                {
                    button.interactable = false; // ��ư Ŭ�� ��Ȱ��ȭ
                    //Debug.Log("��Ȱ��ȭ");
                }
                return;
            }

            // ���� ��� ��ư ��Ȱ��ȭ
            foreach (Button button in unitButtons)
            {
                button.interactable = false; // ��ư Ŭ�� ��Ȱ��ȭ
                //Debug.Log("��Ȱ��ȭ");
            }

            // ������ Ŭ�� ��
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == LayerMask.NameToLayer("DeleteZone"))
            {
                Debug.Log("delete");

                // currentUnitSprite�� null�� �����Ͽ� ���� ����
                currentUnit = null;

                currentUnitSprite = null;

                StartCoroutine(UnitButtonActive());

                return;
            }

            // ���� ��������Ʈ Ȱ��ȭ
            //  currentUnit�� null�� �ƴϾ�� ���� (Ȱ��ȭ���϶���)
            if (currentUnitSprite != null)
            {
                //  ���� ������ Sprite�������� ������Ʈ Ȱ��ȭ
                hit.collider.GetComponent<SpriteRenderer>().sprite = currentUnitSprite;
                hit.collider.GetComponent<SpriteRenderer>().enabled = true;

            }

            // �޼��� Ȱ��ȭ        
            SettingText.gameObject.SetActive(true);


            // Ÿ�� ���콺�� Ŭ�� ��
            if (Input.GetMouseButtonDown(0))
            {
                // ������ ������ ���� 
                if (!hit.collider.GetComponent<Tile>().hasUnits)
                {
                    Debug.Log("��ü ����");
                    // ��ü ����
                    GameObject unitPoint = Instantiate(currentUnit,
                        hit.collider.transform.position, Quaternion.identity);


                    // Hierarchyâ GameManager�ڽ����� ������ ��ü �־��ֱ� 
                    unitPoint.transform.SetParent(this.transform, false);

                    // �浹�� ������Ʈ�� Tile ��ũ��Ʈ ��������
                    Tile tile = hit.collider.GetComponent<Tile>();

                    if (tile != null)
                    {
                        // ������ ���� ���� ����
                        tile.PlaceUnit(unitPoint, currentUnitSprite);
                    };

                    Debug.Log("���� ī����");
                    unitCount.Counting();

                    // �ڸ��� ��ġ�� �Ǿ��ٸ� �޼��� ��Ȱ��ȭ
                    if (hit.collider.GetComponent<Tile>().hasUnits == true)
                    {
                        SettingText.gameObject.SetActive(false);
                    }

                    currentUnit = null;
                    currentUnitSprite = null;

                    StartCoroutine(UnitButtonActive());

                }


                // ���콺�� ������, Ray�� �浹�� ������Ʈ�� Ÿ���� hasUnit�� �ƴ϶��           
                // Ÿ�Ͽ� ������ ���� ���
                if (hit.collider.GetComponent<Tile>().hasUnits)
                {

                    Tile tile = hit.collider.GetComponent<Tile>();

                    if (tile.placedUnit != null)
                    {
                        // ������ ���� Ȱ��ȭ �� ����ٴϵ��� ����


                        // ���ֿ�����Ʈ�� saveZone���� �̵�

                        // ���� Ÿ�Ͽ��� ���� ��������
                        currentUnit = tile.GetplacedUnit();

                        // ������ ��� Ÿ�Ϸ� �̵�
                        tile.MoveUnitToHiddenTile(saveTile);

                        // ��������Ʈ�� currentUnit����
                        currentUnitSprite = tile.GetplacedUnitSprite();
                        tile.PlaceUnit(null, null); // ���� ������ Ÿ�Ͽ��� ����
                        
                    }
                    // Ÿ�Ͽ� ������ ����, �̹� ���õ� ������ ���� ���
                    else if (tile.placedUnit != null)
                    {
                        

                        tile.PlaceUnit(currentUnit, currentUnitSprite); // �� Ÿ�Ͽ� ���� ���� ����
                        currentUnit = null; // ���� ���� ����
                    }

                }
            }
        }
    }

}
