using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Col)
    {
        if (!Col.gameObject.CompareTag(GameTag.Platform.ToString())) return;

        var platformLanded = Col.gameObject.GetComponent<Platform>();

        if (!GameManager.Ins || !GameManager.Ins.Player || !platformLanded) return;

        GameManager.Ins.Player.PlatformLanded = platformLanded;
        GameManager.Ins.Player.Jump();

        if (!GameManager.Ins.IsPlatformLanded(platformLanded.Id))
        {
            int randScore = Random.Range(3, 8);
            GameManager.Ins.AddScore(randScore);
            GameManager.Ins.PlatformLandedIds.Add(platformLanded.Id);
        }
    }
}
