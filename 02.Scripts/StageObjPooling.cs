using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjPooling : MonoBehaviour {

    public static StageObjPooling current;

    public GameObject PoolObj_Sea;
    public GameObject PoolObj_Coin;
    public GameObject[] PoolObj_Wall;
    public GameObject[] PoolObj_Obstacle_1;
    public GameObject[] PoolObj_Obstacle_2;
    public GameObject[] PoolObj_Animals;

    GameObject obj_Sea;
    GameObject obj_Coin;
    GameObject obj_Wall;
    GameObject obj_Obstacle_1;
    GameObject obj_Obstacle_2;
    GameObject obj_Animals;

    public GameObject Play_Obj;  // Pool의 위치

    int PoolAmount_Sea = 2;
    int PoolAmount_Coin = 30;

    public List<GameObject> PoolObjs_Sea;
    public List<GameObject> PoolObjs_Coin;
    public List<GameObject> PoolObjs_Wall;
    public List<GameObject> PoolObjs_Obstacle_1;
    public List<GameObject> PoolObjs_Obstacle_2;
    public List<GameObject> PoolObjs_Animals;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start () {
        // 오브젝트 별 리스트 생성
        PoolObjs_Sea = new List<GameObject>();
        PoolObjs_Coin = new List<GameObject>();
        PoolObjs_Wall = new List<GameObject>();
        PoolObjs_Obstacle_1 = new List<GameObject>();
        PoolObjs_Obstacle_2 = new List<GameObject>();
        PoolObjs_Animals = new List<GameObject>();

        //바다 오브젝트 풀 생성
        for (int i = 0; i < PoolAmount_Sea; i++)
        {
            // 바다 오브젝트 동적 생성
            obj_Sea = (GameObject)Instantiate(PoolObj_Sea);
            // Pool 오브젝트의 자식으로 이동
            obj_Sea.transform.parent = Play_Obj.transform;
            // 바다 오브젝트 비활성화
            obj_Sea.SetActive(false);
            // 위에서 만들어 놓은 PoolObjs_Sea 리스트에 추가
            PoolObjs_Sea.Add(obj_Sea);
        }

        // 코인 오브젝트 풀 생성
        for (int i = 0; i < PoolAmount_Coin; i++)
        {
            // 코인 오브젝트 동적 생성
            obj_Coin = (GameObject)Instantiate(PoolObj_Coin);
            // Pool 오브젝트의 자식으로 이동
            obj_Coin.transform.parent = Play_Obj.transform;
            // 코인 오브젝트 비활성화
            obj_Coin.SetActive(false);
            // 위에서 만들어 놓은 PoolObjs_Coin 리스트에 추가
            PoolObjs_Coin.Add(obj_Coin);
        }

        // 장벽 오브젝트 풀 생성
        for (int i = 0; i < PoolObj_Wall.Length; i++)
        {
            // 장벽 오브젝트 동적 생성
            obj_Wall = (GameObject)Instantiate(PoolObj_Wall[i]);
            // Pool 오브젝트의 자식으로 이동
            obj_Wall.transform.parent = Play_Obj.transform;
            // 장벽 오브젝트 비활성화
            obj_Wall.SetActive(false);
            // 위에서 만들어 놓은 PoolObjs_Wall 리스트에 추가
            PoolObjs_Wall.Add(obj_Wall);
        }

        // 장애물1 오브젝트 풀 생성
        for (int i = 0; i < PoolObj_Obstacle_1.Length; i++)
        {
            // 장애물1 오브젝트 동적 생성
            obj_Obstacle_1 = (GameObject)Instantiate(PoolObj_Obstacle_1[i]);
            // Pool 오브젝트의 자식으로 이동
            obj_Obstacle_1.transform.parent = Play_Obj.transform;
            // 장애물1 오브젝트 비활성화
            obj_Obstacle_1.SetActive(false);
            // 위에서 만들어 놓은 PoolObjs_Obstacle_1 리스트에 추가
            PoolObjs_Obstacle_1.Add(obj_Obstacle_1);
        }

        // 장애물2 오브젝트 풀 생성
        for (int i = 0; i < PoolObj_Obstacle_2.Length; i++)
        {
            // 장애물2 오브젝트 동적 생성
            obj_Obstacle_2 = (GameObject)Instantiate(PoolObj_Obstacle_2[i]);
            // Pool 오브젝트의 자식으로 이동
            obj_Obstacle_2.transform.parent = Play_Obj.transform;
            // 장애물2 오브젝트 비활성화
            obj_Obstacle_2.SetActive(false);
            // 위에서 만들어 놓은 PoolObjs_Obstacle_2 리스트에 추가
            PoolObjs_Obstacle_2.Add(obj_Obstacle_2);
        }

        // 동물 오브젝트 풀 생성
        for (int i = 0; i < PoolObj_Animals.Length; i++)
        {
            // 동물 오브젝트 동적 생성
            obj_Animals = (GameObject)Instantiate(PoolObj_Animals[i]);
            // Pool 오브젝트의 자식으로 이동
            obj_Animals.transform.parent = Play_Obj.transform;
            // 동물 오브젝트 비활성화
            obj_Animals.SetActive(false);
            // 위에서 만들어 놓은 PoolObjs_Animals 리스트에 추가
            PoolObjs_Animals.Add(obj_Animals);
        }

        //for (int i = 0; i < PoolAmount_CannonBall; i++){
        //    obj_CannonBall = (GameObject)Instantiate(PoolObj_CannonBall);
        //    obj_CannonBall.transform.parent = Play_Obj.transform;
        //    obj_CannonBall.SetActive(false);
        //    PoolObjs_CannonBall.Add(obj_CannonBall);
        //}

        //for(int i = 0; i < PoolAmount_WaterEffect; i++)
        //{
        //    obj_WaterEffect = (GameObject)Instantiate(PoolObj_WaterEffect);
        //    obj_WaterEffect.transform.parent = Play_Obj.transform;
        //    obj_WaterEffect.SetActive(false);
        //    PoolObjs_WaterEffect.Add(obj_WaterEffect);
        //}

        //for (int i = 0; i < PoolAmount_CrashEffect; i++)
        //{
        //    obj_CrashEffect = (GameObject)Instantiate(PoolObj_CrashEffect);
        //    obj_CrashEffect.transform.parent = Play_Obj.transform;
        //    obj_CrashEffect.SetActive(false);
        //    PoolObjs_CrashEffect.Add(obj_CrashEffect);
        //}

        //for (int i = 0; i < PoolAmount_Enemy; i++)
        //{
        //    obj_Enemy = (GameObject)Instantiate(PoolObj_Enemy);
        //    obj_Enemy.transform.parent = Play_Obj.transform;
        //    obj_Enemy.SetActive(false);
        //    PoolObjs_Enemy.Add(obj_Enemy);
        //}
    }

    // 오브젝트 풀에서 바다 오브젝트를 반환하는 함수
    public GameObject GetPooledObject_Sea()
    {
        for (int i = 0; i < PoolObjs_Sea.Count; i++)
        {
            // 비활성화 상태의 오브젝트가 있다면
            if (!PoolObjs_Sea[i].activeInHierarchy) return PoolObjs_Sea[i];
        }
        return null;
    }

    // 오브젝트 풀에서 코인 오브젝트를 반환하는 함수
    public GameObject GetPooledObject_Coin()
    {
        for (int i = 0; i < PoolObjs_Coin.Count; i++)
        {
            // 비활성화 상태의 오브젝트가 있다면
            if (!PoolObjs_Coin[i].activeInHierarchy) return PoolObjs_Coin[i];
        }
        // 비활성화 상태의 오브젝트가 없다면 null 반환
        return null;
    }

    // 오브젝트 풀에서 장벽 오브젝트를 반환하는 함수
    public GameObject GetPooledObject_Wall()
    {
        // 5개 종류의 장벽 중 하나 랜덤 선택
        int i = Random.Range(0, PoolObj_Wall.Length);
        // 비활성화 상태의 오브젝트가 있다면
        if (!PoolObjs_Wall[i].activeInHierarchy) return PoolObjs_Wall[i];
        // 비활성화 상태의 오브젝트가 없다면 null 반환
        return null;
    }

    // 오브젝트 풀에서 장애물1 오브젝트를 반환하는 함수
    public GameObject GetPooledObject_Obstacle_1()
    {
        for(int i = 0; i<PoolObjs_Obstacle_1.Count; i++)
        {
            // 비활성화 상태의 오브젝트가 있다면
            if (!PoolObjs_Obstacle_1[i].activeInHierarchy) return PoolObjs_Obstacle_1[i];
        }
        // 비활성화 상태의 오브젝트가 없다면 null 반환
        return null;
    }

    // 오브젝트 풀에서 장애물2 오브젝트를 반환하는 함수
    public GameObject GetPooledObject_Obstacle_2()
    {
        for (int i = 0; i < PoolObjs_Obstacle_2.Count; i++)
        {
            // 비활성화 상태의 오브젝트가 있다면
            if (!PoolObjs_Obstacle_2[i].activeInHierarchy) return PoolObjs_Obstacle_2[i];
        }
        // 비활성화 상태의 오브젝트가 없다면 null 반환
        return null;
    }

    // 오브젝트 풀에서 동물 오브젝트를 반환하는 함수
    public GameObject GetPooledObject_Animals()
    {
        // 7종류의 동물 중 하나 랜덤 선택
        int i = Random.Range(0, PoolObjs_Animals.Count);
        // 비활성화 상태의 오브젝트가 있다면
        if (!PoolObjs_Animals[i].activeInHierarchy) return PoolObjs_Animals[i];
        // 비활성화 상태의 오브젝트가 없다면 null 반환
        return null;
    }

    //public GameObject GetPooledObject_CannonBall()
    //{
    //    for(int i = 0; i < PoolObjs_CannonBall.Count; i++)
    //    {
    //        if (!PoolObjs_CannonBall[i].activeInHierarchy)
    //        {
    //            return PoolObjs_CannonBall[i];
    //        }
    //    }
    //    return null;
    //}

    //public GameObject GetPooledObject_WaterEffect()
    //{
    //    for(int i = 0; i < PoolObjs_WaterEffect.Count; i++)
    //    {
    //        if (!PoolObjs_WaterEffect[i].activeInHierarchy)
    //        {
    //            return PoolObjs_WaterEffect[i];
    //        }
    //    }
    //    return null;
    //}

    //public GameObject GetPooledObject_CrashEffect()
    //{
    //    for (int i = 0; i < PoolObjs_CrashEffect.Count; i++)
    //    {
    //        if (!PoolObjs_CrashEffect[i].activeInHierarchy)
    //        {
    //            return PoolObjs_CrashEffect[i];
    //        }
    //    }
    //    return null;
    //}

    //public GameObject GetPooledObject_Enemy()
    //{
    //    for(int i = 0; i < PoolObjs_Enemy.Count; i++)
    //    {
    //        if (!PoolObjs_Enemy[i].activeInHierarchy)
    //        {
    //            return PoolObjs_Enemy[i];
    //        }
    //    }
    //    return null;
    //}
}
