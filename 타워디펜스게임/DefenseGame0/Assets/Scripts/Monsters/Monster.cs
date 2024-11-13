using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }
}
