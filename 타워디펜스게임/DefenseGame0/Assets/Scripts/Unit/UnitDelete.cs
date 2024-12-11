using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDelete : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private string destroyZone = "DestroyZone";

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameManager.currentUnitSprite)
        {
            if (collision.gameObject.transform.position == collision.transform.position)
            {
                Debug.Log("Destroy");
                Destroy(collision.gameObject);

            }
        }
    }

}
