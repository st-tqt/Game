using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFollowCam : MonoBehaviour
{
    private Vector3 m_startingPos;

    private void Awake()
    {
        m_startingPos = transform.position;
    }

    void Update()
    {
        transform.position = m_startingPos;
    }
}
