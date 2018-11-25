using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjPooling : MonoBehaviour {

    public static StageObjPooling current;

   // public GameObject PoolObj_A;
    //public GameObject PoolObj_B;
    public GameObject PoolObj_CannonBall;
    public GameObject PoolObj_Sea;
    public GameObject PoolObj_Coin;
    public GameObject[] PoolObj_Wall;
    public GameObject[] PoolObj_Obstacle_1;
    public GameObject[] PoolObj_Obstacle_2;


    public GameObject Play_Obj;

    //public int PoolAmount_A = 5;
    //public int PoolAmount_B = 5;
    public int PoolAmount_CannonBall = 1;
    public int PoolAmount_Sea = 5;
    public int PoolAmount_Coin = 30;

    //public List<GameObject> PoolObjs_A;
    //public List<GameObject> PoolObjs_B;
    public List<GameObject> PoolObjs_CannonBall;
    public List<GameObject> PoolObjs_Sea;
    public List<GameObject> PoolObjs_Coin;
    public List<GameObject> PoolObjs_Wall;
    public List<GameObject> PoolObjs_Obstacle_1;
    public List<GameObject> PoolObjs_Obstacle_2;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start () {
        //PoolObjs_A = new List<GameObject>();
        //PoolObjs_B = new List<GameObject>();
        PoolObjs_CannonBall = new List<GameObject>();
        PoolObjs_Sea = new List<GameObject>();
        PoolObjs_Coin = new List<GameObject>();
        PoolObjs_Wall = new List<GameObject>();
        PoolObjs_Obstacle_1 = new List<GameObject>();
        PoolObjs_Obstacle_2 = new List<GameObject>();

        //for (int i = 0; i < PoolAmount_A; i++)
        //{
        //    GameObject obj_A = (GameObject)Instantiate(PoolObj_A);

        //    obj_A.transform.parent = Play_Obj.transform;

        //    obj_A.SetActive(false);
        //    PoolObjs_A.Add(obj_A);
        //}

        //for(int i = 0; i < PoolAmount_B; i++)
        //{
        //    GameObject obj_B = (GameObject)Instantiate(PoolObj_B);

        //    obj_B.transform.parent = Play_Obj.transform;

        //    obj_B.SetActive(false);
        //    PoolObjs_B.Add(obj_B);
        //}

        for (int i = 0; i < PoolAmount_Sea; i++)
        {
            GameObject obj_Sea = (GameObject)Instantiate(PoolObj_Sea);

            obj_Sea.transform.parent = Play_Obj.transform;

            obj_Sea.SetActive(false);
            PoolObjs_Sea.Add(obj_Sea);
        }

        for (int i = 0; i < PoolAmount_Coin; i++)
        {
            GameObject obj_Coin = (GameObject)Instantiate(PoolObj_Coin);

            obj_Coin.transform.parent = Play_Obj.transform;

            obj_Coin.SetActive(false);
            PoolObjs_Coin.Add(obj_Coin);
        }

        for (int i = 0; i < PoolObj_Wall.Length; i++)
        {
            GameObject obj_Wall = (GameObject)Instantiate(PoolObj_Wall[i]);

            obj_Wall.transform.parent = Play_Obj.transform;

            obj_Wall.SetActive(false);
            PoolObjs_Wall.Add(obj_Wall);
        }

        for (int i = 0; i < PoolObj_Obstacle_1.Length; i++)
        {
            GameObject obj_Obstacle_1 = (GameObject)Instantiate(PoolObj_Obstacle_1[i]);

            obj_Obstacle_1.transform.parent = Play_Obj.transform;

            obj_Obstacle_1.SetActive(false);
            PoolObjs_Obstacle_1.Add(obj_Obstacle_1);
        }

        for (int i = 0; i < PoolObj_Obstacle_2.Length; i++)
        {
            GameObject obj_Obstacle_2 = (GameObject)Instantiate(PoolObj_Obstacle_2[i]);

            obj_Obstacle_2.transform.parent = Play_Obj.transform;

            obj_Obstacle_2.SetActive(false);
            PoolObjs_Obstacle_2.Add(obj_Obstacle_2);
        }

        for (int i = 0; i < PoolAmount_CannonBall; i++)
        {
            GameObject obj_CannonBall = (GameObject)Instantiate(PoolObj_CannonBall);

            obj_CannonBall.transform.parent = Play_Obj.transform;

            obj_CannonBall.SetActive(false);
            PoolObjs_CannonBall.Add(obj_CannonBall);
        }
    }

    //public GameObject GetPooledObject_A()
    //{
    //    for(int i = 0; i < PoolObjs_A.Count; i++)
    //    {
    //        if (!PoolObjs_A[i].activeInHierarchy)
    //        {
    //            return PoolObjs_A[i];
    //        }
    //    }
    //    return null;
    //}

    //public GameObject GetPooledObject_B()
    //{
    //    for (int i = 0; i < PoolObjs_B.Count; i++)
    //    {
    //        if (!PoolObjs_B[i].activeInHierarchy)
    //        {
    //            return PoolObjs_B[i];
    //        }
    //    }
    //    return null;
    //}

    public GameObject GetPooledObject_Sea()
    {
        for (int i = 0; i < PoolObjs_Sea.Count; i++)
        {
            if (!PoolObjs_Sea[i].activeInHierarchy)
            {
                return PoolObjs_Sea[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject_Coin()
    {
        for (int i = 0; i < PoolObjs_Coin.Count; i++)
        {
            if (!PoolObjs_Coin[i].activeInHierarchy)
            {
                return PoolObjs_Coin[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject_Wall()
    {
        int i = Random.Range(0, PoolObj_Wall.Length);
        if (!PoolObjs_Wall[i].activeInHierarchy)
        {
            return PoolObjs_Wall[i];
        }
        return null;
    }

    public GameObject GetPooledObject_Obstacle_1()
    {
        //int i = Random.Range(0, PoolObj_Obstacle_1.Length);
        for(int i = 0; i<PoolObjs_Obstacle_1.Count; i++)
        {
            if (!PoolObjs_Obstacle_1[i].activeInHierarchy)
            {
                return PoolObjs_Obstacle_1[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject_Obstacle_2()
    {
        //int i = Random.Range(0, PoolObj_Obstacle_1.Length);
        for (int i = 0; i < PoolObjs_Obstacle_2.Count; i++)
        {
            if (!PoolObjs_Obstacle_2[i].activeInHierarchy)
            {
                return PoolObjs_Obstacle_2[i];
            }
        }
        return null;
    }

    public GameObject GetPooledObject_CannonBall()
    {
        for (int i = 0; i < PoolObjs_CannonBall.Count; i++)
        {
            if (!PoolObjs_CannonBall[i].activeInHierarchy)
            {
                return PoolObjs_CannonBall[i];
            }
        }
        return null;
    }
}
