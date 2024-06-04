using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform cSpawnPoint;

    private int m_id;
    protected Player m_Player;
    protected Rigidbody2D m_rb;

    public int Id { get => m_id; set => m_id = value; }

    protected virtual void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        if (!GameManager.Ins) return;
        m_Player = GameManager.Ins.Player;

        if (cSpawnPoint)
        {
            GameManager.Ins.SpawnCollectable(cSpawnPoint);
        }
    }

    public virtual void PlatformAction()
    {

    }
}
