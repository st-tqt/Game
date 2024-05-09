using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed = 10;
    float xDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        float moveStep = moveSpeed * xDirection * Time.deltaTime;

        if ((transform.position.x <= -9.5 && xDirection == -1) || (transform.position.x >= 9.5 && xDirection == 1))
            return;

        transform.position = transform.position + new Vector3(moveStep, 0, 0);
    }
}
