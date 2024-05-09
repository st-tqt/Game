using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float speed;
    GameController m_gc;
    AudioSource aus;
    public AudioClip hitSound;
    public GameObject hitVFX;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 5.5)
            Destroy(gameObject);
        m_rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Enemy"))
        {
            m_gc.ScoreIncrement();

            if (aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }

            if (hitVFX)
            {
                Instantiate(hitVFX, Col.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
            Destroy(Col.gameObject);
            Debug.Log("Va cham voi Enemy");
        }
    }

}
