/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObj : MonoBehaviour {

    public Vector3[] SpawnPoints;

    int x = -89;

    int z = -20;

    int index = 0;


    

    void Awake()
    {
        Make_Point(SpawnPoints);
    }

    void Start()
    {
        Random_Set(SpawnPoints);
    }


    void Random_Set(Vector3[] SpawnPoint)
    {
        int index = 0; // 시작 스폰포인트 번호
        int SetNum; //셋팅갯수 변수 선언
        int SetKinds; //셋팅 종류 선언
        int[] indexArray; // 2개 이상의 오브젝트 생성시 사용하는 랜덤 생성 스폰번호

        for (int i = 0; i < 10; i++) //10번의 생성
        {
            SetNum = Random.Range(1, 4); //셋팅갯수 설정
            switch (SetNum) {
                case 1:
                    index = Random.Range(index, index + 4);
                    SetKinds = Random.Range(0, 2);
                    switch (SetKinds)
                    {
                        case 1:
                            Active_Rock(SpawnPoint[index]);
                            break;

                        case 2:
                            Active_Island(SpawnPoint[index]);
                            break;

                        case 3:
                            Active_Ship(SpawnPoint[index]);
                            break;
                    }
                    index += 5;
                    break;

                case 2:
                    indexArray = getRandomInt(2, index, index + 4);
                    for (int j = 0; j < 2; j++)
                    {
                        SetKinds = Random.Range(0, 2);
                        switch (SetKinds)
                        {
                            case 1:
                                Active_Rock(SpawnPoint[indexArray[j]]);
                                break;

                            case 2:
                                Active_Island(SpawnPoint[indexArray[j]]);
                                break;

                            case 3:
                                Active_Ship(SpawnPoint[indexArray[j]]);
                                break;
                        }                  
                    }
                    index += 5;
                    break;

                case 3:
                    indexArray = getRandomInt(3, index, index + 4);
                    for (int j = 0; j < 3; j++)
                    {
                        SetKinds = Random.Range(0, 2);
                        switch (SetKinds)
                        {
                            case 1:
                                Active_Rock(SpawnPoint[indexArray[j]]);
                                break;

                            case 2:
                                Active_Island(SpawnPoint[indexArray[j]]);
                                break;

                            case 3:
                                Active_Ship(SpawnPoint[indexArray[j]]);
                                break;
                        }
                    }
                    index += 5;
                    break;

                case 4:
                    indexArray = getRandomInt(3, index, index + 4);
                    for (int j = 0; j < 3; j++)
                    {
                        SetKinds = Random.Range(0, 2);
                        switch (SetKinds)
                        {
                            case 1:
                                Active_Rock(SpawnPoint[indexArray[j]]);
                                break;

                            case 2:
                                Active_Island(SpawnPoint[indexArray[j]]);
                                break;

                            case 3:
                                Active_Ship(SpawnPoint[indexArray[j]]);
                                break;
                        }
                    }
                    index += 5;
                    break;



            }
        }
        

    }


    void Make_Point(Vector3[] spawnpoints) //스폰 포인트 제작 함수
    {
        spawnpoints = new Vector3[50];
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                spawnpoints.SetValue(new Vector3(x, 0, z), index);
                z += 10;
                index++;
            }
            x += 20;
            z = -20;
        }
    }


    // 풀링 연결 함수 모음
    void Active_Rock(Vector3 spawnpoint) //바위 연결 풀링 함수
    {
        GameObject obj_Rock = StageObjPooling.current.GetPooledObject_Rock();

        if (obj_Rock == null) return;

        obj_Rock.transform.position = spawnpoint;
        obj_Rock.SetActive(true);
    }

    void Active_Island(Vector3 spawnpoint) //섬 연결 풀링 함수
    {
        GameObject obj_Island = StageObjPooling.current.GetPooledObject_Island();

        if (obj_Island == null) return;

        obj_Island.transform.position = spawnpoint;
        obj_Island.SetActive(true);
    }

    void Active_Ship(Vector3 spawnpoint) //배 연결 풀링 함수
    {
        GameObject obj_Island = StageObjPooling.current.GetPooledObject_Island();

        if (obj_Island == null) return;

        obj_Island.transform.position = spawnpoint;
        obj_Island.SetActive(true);
    }

    public int[] getRandomInt(int length, int min, int max) //중복없는 난수 생성 함수
    {
        int[] randArray = new int[length];
        bool isSame;

        for (int i = 0; i < length; ++i)
        {
            while (true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for (int j = 0; j < i; ++j)
                {
                    if (randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    }


}
*/