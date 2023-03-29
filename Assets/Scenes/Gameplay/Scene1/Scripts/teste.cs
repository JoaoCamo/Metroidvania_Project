using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    private float speed = 0.5f;

    private void Update()
    { 
        float xInput = Input.GetAxisRaw("Horizontal") * speed;
        Vector3 move = new Vector3(xInput * Time.deltaTime, 0, 0);
        transform.Translate(move);
    }
}
