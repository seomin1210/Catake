using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBody : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
    }
}
