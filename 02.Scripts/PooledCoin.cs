﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledCoin : MonoBehaviour
{
    // 코인 1 증가 함수
    public void Score_Coin()
    {
        MiniGameController.instance.Score(1);
    }

    void OnTriggerEnter(Collider collision)
    {
        // 카메라 범위를 지나갈 경우 
        if (collision.CompareTag("Obstacle_endline")) this.gameObject.SetActive(false);

        // 플레이어와 접촉할 경우
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlayCoinSound(); // 코인 효과음 재생
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            Score_Coin();
        }
    }
}