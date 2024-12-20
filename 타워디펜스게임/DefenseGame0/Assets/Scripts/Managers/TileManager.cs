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

    public void BuyUnit(GameObject unitPrefab, Sprite sprite)
    {
        // ������ ������ ���� Instantiate ȣ��
        if (currentUnit == null)
        {
            currentUnit = Instantiate(unitPrefab, saveTile.position, Quaternion.identity);
            currentUnit.SetActive(false); // ���� �� ��� ����
        }

        currentUnitSprite = sprite; // ��������Ʈ ����
        currentUnit.SetActive(true); // ���� Ȱ��ȭ
    }

    public bool UnitOver()
    {
        // ������ ������ �Ѱ� ������ �������� ���̻� �����Ұ�
        if (unitCount.GetUnitTotalCount() == unitCount.GetUnitCount())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // �ڷ�ƾ ����ؼ� ��ư�� 1�ʵڿ� Ȱ��ȭ�ǰ�
    IEnumerator UnitButtonActive()
    {
        yield return new WaitForSeconds(1.0f);

        // ���� ��� ��ư Ȱ��ȭ
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

        // �ݺ������� Ÿ�� �������� ��Ȱ��ȭ
        foreach (Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }

        // ���콺 �ݶ��̴��� (���ָ�Ͽ��� ������) ������ �浹�Ѵٸ�
        if (hit.collider && currentUnit)
        {
            // ������ �� ���� ��ư ��Ȱ��ȭ
            if (UnitOver() == true)
            {
                foreach (Button button in unitButtons)
                {
                    button.interactable = false;
                }
                return;
            }

            // ������ Ŭ�� ��
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.layer == LayerMask.NameToLayer("DeleteZone"))
            {
                Debug.Log("Delete Unit");
                currentUnit.transform.position = saveTile.position; // ���̺������� �̵�
                currentUnit.SetActive(false); // ���� ��Ȱ��ȭ
                currentUnitSprite = null;
                currentUnit = null;

                StartCoroutine(UnitButtonActive());
                return;
            }

            // ���� ��������Ʈ Ȱ��ȭ
            if (currentUnitSprite != null)
            {
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
                    Tile tile = hit.collider.GetComponent<Tile>();

                    currentUnit.transform.position = hit.collider.transform.position; // Ÿ�Ϸ� �̵�
                    tile.PlaceUnit(currentUnit, currentUnitSprite); // Ÿ�Ͽ� ���� ����

                    unitCount.Counting(); // ���� ī��Ʈ ����

                    if (tile.hasUnits == true)
                    {
                        SettingText.gameObject.SetActive(false); // �޽��� ��Ȱ��ȭ
                    }

                    currentUnit = null;
                    currentUnitSprite = null;

                    StartCoroutine(UnitButtonActive());
                }
            }
        }

        // Ÿ�Ͽ� ������ �ְ�, Ŭ���߰�, ��������Ʈ ���� ��
        if (hit.collider != null && hit.collider.GetComponent<Tile>() != null
            && hit.collider.GetComponent<Tile>().hasUnits && currentUnitSprite == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Tile tile = hit.collider.GetComponent<Tile>();

                if (tile.placedUnit != null)
                {
                    currentUnit = tile.GetplacedUnit(); // Ÿ�Ͽ��� ���� ��������
                    currentUnitSprite = tile.GetplacedUnitSprite();

                    tile.PlaceUnit(null, null); // Ÿ�Ͽ��� ���� ����
                    currentUnit.transform.position = saveTile.position; // ���̺������� �̵�
                }
            }
        }
    }
}

