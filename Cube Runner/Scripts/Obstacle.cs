using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("SceneLimit"))
        {
            m_gc.ScoreIncrement();
            Debug.Log("Da ra ngoai khung hinh");
            Destroy(gameObject);
        }
    }

}
