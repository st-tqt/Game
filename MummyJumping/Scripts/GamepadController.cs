using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadController : Singleton<GamepadController>
{
    public bool isOnMobile;
    private bool m_CanMoveLeft;
    private bool m_CanMoveRight;

    public bool CanMoveLeft { get => m_CanMoveLeft; set => m_CanMoveLeft = value; }
    public bool CanMoveRight { get => m_CanMoveRight; set => m_CanMoveRight = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    private void Update()
    {
        if (isOnMobile) return;

        m_CanMoveLeft = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        m_CanMoveRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }
}
