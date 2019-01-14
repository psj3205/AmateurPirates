using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledAnimals : MonoBehaviour
{

    // 코인 10 증가 함수
    public void Score_Animals()
    {
        MiniGameController.instance.Score(10);
    }

    void OnTriggerEnter(Collider collision)
    {
        // 카메라 범위를 지나갈 경우 
        if (collision.CompareTag("Obstacle_endline")) this.gameObject.SetActive(false); // 비활성화

        // 플레이어와 접촉할 경우
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlayAnimalSound(); // 동물 효과음 재생
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            Score_Animals();
        }
    }
}
