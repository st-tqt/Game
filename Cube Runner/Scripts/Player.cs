using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float JumpForce;
    bool m_isGround;
    public Animator anim;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPressed && m_isGround)
        {
            m_rb.AddForce(Vector2.up * JumpForce);
            m_isGround = false;
            anim.SetTrigger("Space");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Obstacle"))
        {
            m_gc.SetIsGameOver(true);
            Debug.Log("Va cham");
        }
    }

}
