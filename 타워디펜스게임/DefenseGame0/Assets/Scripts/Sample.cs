using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{

    public Transform Pos;
    private Vector2 BoxSize = new Vector2(1, 1);

    void Start()
    {
        Pos.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(Pos.position, BoxSize, 0);

        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.name == "Enemy")
                Debug.Log("Ãæµ¹");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)Pos.position + new Vector2(-1, 0), BoxSize * 4);
    }
}
