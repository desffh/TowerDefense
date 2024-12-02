using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Vector3 FinalDestination; // µµÂø ÁöÁ¡

    public float moveSpeed = 0.2f;

    private bool isStopped;

    private void FixedUpdate()
    {
        if(!isStopped)
        {
            transform.Translate(new Vector3(moveSpeed * -1, 0, 0));         
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            isStopped = true;
        }
    }


}
