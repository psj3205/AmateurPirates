using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageTipSize = 200;   // 바다 오브젝트의 크기

    int currentTipIndex;            // 현재 플레이어가 위치한 바다 오브젝트의 위치 인덱스

    public Transform character;
    public int startTipIndex;       // 플레이어 시작 위치 인덱스
    public int preInstantiate;      // 미리 생성할 바다 오브젝트의 수

    GameObject obj_Sea;
    GameObject obj_Wall;
    GameObject obj_Obstacle_1;
    GameObject obj_Obstacle_2;
    GameObject obj_Coin;
    GameObject obj_Animals;
    GameObject obj_Cannon;
    GameObject obj_Enemy;

    void Start()
    {
        currentTipIndex = startTipIndex;
        UpdateStage(preInstantiate);    // 미리 생성할 바다 오브젝트 생성
    }

    void Update()
    {
        // 플레이어의 위치 인덱스 계산
        int characterPositionIndex = (int)(character.position.x / StageTipSize);
        // 플레이어가 앞으로 진행함에 따라 진행경로에 바다 오브젝트 생성(오브젝트 풀 이용)
        if (characterPositionIndex + preInstantiate > currentTipIndex) UpdateStage(characterPositionIndex + preInstantiate);
    }

    // 스테이지 생성 함수
    void UpdateStage(int toTipIndex)
    {
        // 현재 플레이어의 위치가 toTipIndex보다 뒤에 있으면 종료
        if (toTipIndex <= currentTipIndex) return;

        // 플레이어가 앞으로 이동하면 이동 경로에 맵을 생성
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            // 바다 오브젝트 생성
            Active_Sea(i);
            // 바다 오브젝트 30까지. 장애물, 코인, 동물 배치
            if (i < 30) Active_Map_30(i);
            // 바다 오브젝트 60부터(난이도 상승). 장애물, 코인, 동물 배치
            else Active_Map_60(i);
        }
        // 현재 위치 인덱스 업데이트
        currentTipIndex = toTipIndex;
    }

    // 바다 오브젝트 활성화 함수
    void Active_Sea(int idx)
    {
        // StageObjPooling 객체의 오브젝트 풀에서 바다 오브젝트를 리턴
        obj_Sea = StageObjPooling.current.GetPooledObject_Sea();

        // 성공적으로 바다 오브젝트를 리턴하였다면 
        if (obj_Sea != null)
        {
            obj_Sea.transform.position = new Vector3(idx * StageTipSize, 0, 0); // 플레이어의 위치 인덱스에 맞게 바다 오브젝트 위치 설정
            obj_Sea.SetActive(true);                                            // 바다 오브젝트 활성화
        }
    }

    // 스테이지 활성화 함수(바다 오브젝트 수 30까지)
    void Active_Map_30(int idx)
    {
        // 바다를 20x20 좌표평면으로 가정함
        for (int i = 0; i < 20; i++)
        {
            // 플레이어 진행방향의 3의 배수의 좌표값에서
            if (i % 3 == 0)
            {
                // 10%의 확률로 장벽 장애물 생성
                if (Random.value < 0.1)
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 장벽 오브젝트를 리턴
                    obj_Wall = StageObjPooling.current.GetPooledObject_Wall();
                    // 성공적으로 장벽 오브젝트를 리턴하였다면 
                    if (obj_Wall != null)
                    {
                        obj_Wall.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, 0); // 플레이어의 위치 인덱스에 맞게 장벽 오브젝트 위치 설정
                        obj_Wall.SetActive(true);                                                             // 장벽 오브젝트 활성화
                    }
                }
                // 70%의 확률로 장애물1 오브젝트 생성
                else if (Random.value >= 0.1 && Random.value < 0.8)
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물1 오브젝트를 리턴
                    obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    // 성공적으로 장애물1 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_1 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물1 오브젝트 위치 설정
                        obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 1) * 10);
                        // 장애물1 오브젝트 활성화
                        obj_Obstacle_1.SetActive(true);
                    }
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물1 오브젝트를 리턴
                    obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    // 성공적으로 장애물1 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_1 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물1 오브젝트 위치 설정
                        obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(1, 3) * 10);
                        // 장애물1 오브젝트 활성화
                        obj_Obstacle_1.SetActive(true);
                    }
                }
                // 나머지 위치
                else
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물2 오브젝트를 리턴
                    obj_Obstacle_2 = StageObjPooling.current.GetPooledObject_Obstacle_2();
                    // 성공적으로 장애물2 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_2 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물2 오브젝트 위치 설정
                        obj_Obstacle_2.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 3) * 10);
                        // 장애물2 오브젝트 활성화
                        obj_Obstacle_2.SetActive(true);
                    }
                }
            }
            // 플레이어 진행방향의 7의 배수의 좌표값에서
            else if (i % 7 == 0)
            {
                // 20%의 확률로 동물 오브젝트 활성화
                if (Random.value >= 0.8)
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 동물 오브젝트를 리턴
                    obj_Animals = StageObjPooling.current.GetPooledObject_Animals();
                    // 성공적으로 동물 오브젝트를 리턴하였다면 
                    if (obj_Animals != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 동물 오브젝트 위치 설정
                        obj_Animals.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 2.5f, Random.Range(-2, 3) * 10);
                        // 동물 오브젝트 활성화
                        obj_Animals.SetActive(true);
                    }
                }
            }
            // 나머지 위치
            else
            {
                // StageObjPooling 객체의 오브젝트 풀에서 코인 오브젝트를 리턴
                obj_Coin = StageObjPooling.current.GetPooledObject_Coin();
                // 성공적으로 코인 오브젝트를 리턴하였다면 
                if (obj_Coin != null)
                {
                    // 플레이어의 위치 인덱스에 맞게 코인 오브젝트 위치 설정
                    obj_Coin.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 1, Random.Range(-2, 1) * 10);
                    // 코인 오브젝트 활성화
                    obj_Coin.SetActive(true);
                }
                // StageObjPooling 객체의 오브젝트 풀에서 코인 오브젝트를 리턴
                obj_Coin = StageObjPooling.current.GetPooledObject_Coin();
                // 성공적으로 코인 오브젝트를 리턴하였다면 
                if (obj_Coin != null)
                {
                    // 플레이어의 위치 인덱스에 맞게 코인 오브젝트 위치 설정
                    obj_Coin.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 1, Random.Range(1, 3) * 10);
                    // 코인 오브젝트 활성화
                    obj_Coin.SetActive(true);
                }
            }
        }
    }

    // 스테이지 활성화 함수(바다 오브젝트 수 60부터(난이도 증가))
    void Active_Map_60(int idx)
    {
        for (int i = 0; i < 20; i++)
        {
            // 플레이어 진행방향의 3의 배수의 좌표값에서
            if (i % 3 == 0)
            {
                // 10%의 확률로 장벽 오브젝트 활성화
                if (Random.value < 0.1)
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 장벽 오브젝트를 리턴
                    obj_Wall = StageObjPooling.current.GetPooledObject_Wall();
                    // 성공적으로 장벽 오브젝트를 리턴하였다면 
                    if (obj_Wall != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장벽 오브젝트 위치 설정
                        obj_Wall.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, 0);
                        // 장벽 오브젝트 활성화
                        obj_Wall.SetActive(true);
                    }
                }
                // 70%의 확률로 장애물1 오브젝트 활성화
                else if (Random.value >= 0.1 && Random.value < 0.8)
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물1 오브젝트를 리턴
                    obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    // 성공적으로 장애물1 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_1 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물1 오브젝트 위치 설정
                        obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 0) * 10);
                        // 장애물1 오브젝트 활성화
                        obj_Obstacle_1.SetActive(true);
                    }
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물1 오브젝트를 리턴
                    obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    // 성공적으로 장애물1 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_1 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물1 오브젝트 위치 설정
                        obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(0, 1) * 10);
                        // 장애물1 오브젝트 활성화
                        obj_Obstacle_1.SetActive(true);
                    }
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물1 오브젝트를 리턴
                    obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    // 성공적으로 장애물1 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_1 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물1 오브젝트 위치 설정
                        obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(1, 3) * 10);
                        // 장애물1 오브젝트 활성화
                        obj_Obstacle_1.SetActive(true);
                    }
                }
                // 나머지 위치
                else
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물2 오브젝트를 리턴
                    obj_Obstacle_2 = StageObjPooling.current.GetPooledObject_Obstacle_2();
                    // 성공적으로 장애물2 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_2 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물2 오브젝트 위치 설정
                        obj_Obstacle_2.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 1) * 10);
                        // 장애물2 오브젝트 활성화
                        obj_Obstacle_2.SetActive(true);
                    }
                    // StageObjPooling 객체의 오브젝트 풀에서 장애물2 오브젝트를 리턴
                    obj_Obstacle_2 = StageObjPooling.current.GetPooledObject_Obstacle_2();
                    // 성공적으로 장애물2 오브젝트를 리턴하였다면 
                    if (obj_Obstacle_2 != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 장애물2 오브젝트 위치 설정
                        obj_Obstacle_2.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(1, 3) * 10);
                        // 장애물2 오브젝트 활성화
                        obj_Obstacle_2.SetActive(true);
                    }
                }
            }
            // 플레이어 진행방향의 7의 배수의 좌표값에서
            else if (i % 7 == 0)
            {
                // 50%의 확률로 동물 오브젝트 활성화
                if (Random.value >= 0.5)
                {
                    // StageObjPooling 객체의 오브젝트 풀에서 동물 오브젝트를 리턴
                    obj_Animals = StageObjPooling.current.GetPooledObject_Animals();
                    // 성공적으로 동물 오브젝트를 리턴하였다면 
                    if (obj_Animals != null)
                    {
                        // 플레이어의 위치 인덱스에 맞게 동물 오브젝트 위치 설정
                        obj_Animals.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 2.5f, Random.Range(-2, 3) * 10);
                        // 동물 오브젝트 활성화
                        obj_Animals.SetActive(true);
                    }
                }
            }
            // 나머지 위치
            else
            {
                // StageObjPooling 객체의 오브젝트 풀에서 코인 오브젝트를 리턴
                obj_Coin = StageObjPooling.current.GetPooledObject_Coin();
                // 성공적으로 코인 오브젝트를 리턴하였다면 
                if (obj_Coin != null)
                {
                    // 플레이어의 위치 인덱스에 맞게 코인 오브젝트 위치 설정
                    obj_Coin.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 1, Random.Range(-2, 1) * 10);
                    // 코인 오브젝트 활성화
                    obj_Coin.SetActive(true);
                }
                // StageObjPooling 객체의 오브젝트 풀에서 코인 오브젝트를 리턴
                obj_Coin = StageObjPooling.current.GetPooledObject_Coin();
                // 성공적으로 코인 오브젝트를 리턴하였다면 
                if (obj_Coin != null)
                {
                    // 플레이어의 위치 인덱스에 맞게 코인 오브젝트 위치 설정
                    obj_Coin.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 1, Random.Range(1, 3) * 10);
                    // 코인 오브젝트 활성화
                    obj_Coin.SetActive(true);
                }
            }
        }
    }
}

