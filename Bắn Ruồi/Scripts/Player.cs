using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject projectile;
    public Transform shootingPoint;
    public AudioSource aus;
    public AudioClip shootingSound;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        
        if ((xDir < 0 && transform.position.x <= -11.5) || (xDir > 0 && transform.position.x >= 11.5) || (m_gc.IsGameOver()))
            return;
        
        transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (projectile && shootingPoint)
        {
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }

            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            m_gc.SetGameOverState(true);
            Debug.Log("Va cham voi Player");
        }
    }

}
