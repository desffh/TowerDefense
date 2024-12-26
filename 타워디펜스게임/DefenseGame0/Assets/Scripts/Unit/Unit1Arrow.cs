using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1Arrow : MonoBehaviour
{
    // È° ÇÁ¸®ÆÕ
    [SerializeField] private GameObject unit1arrow;

    public GameObject bowObj;

    public GameObject Unit1Obj;

    private void Start()
    {
    }

    public void SpawnArrow()
    {
        Vector3 pos = Unit1Obj.transform.position;


        bowObj = Instantiate(unit1arrow, pos, Quaternion.identity);

    }


}
