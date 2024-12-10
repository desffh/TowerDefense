using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDelete : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private string destroyZone = "DestroyZone";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D called"); // 함수 호출 확인
        if (collision.gameObject == gameManager.currentUnit && collision.CompareTag(destroyZone))
        {
            Debug.Log("Destroy");
            Destroy(collision.gameObject);
        }
    }

}
