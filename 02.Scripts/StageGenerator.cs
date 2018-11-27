using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageTipSize = 200;

    int currentTipIndex;

    public Transform character;
    //public GameObject[] stageTips;
    public int startTipIndex;
    public int preInstantiate;
    //public List<GameObject> generatedStageList = new List<GameObject>();

    //private Vector3 PosObj_A;
    //private Vector3 PosObj_B;
    //private Vector3 PosObj_Sea;

    // Use this for initialization
    void Start()
    {
        currentTipIndex = startTipIndex;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        int characterPositionIndex = (int)(character.position.x / StageTipSize);

        if (characterPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(characterPositionIndex + preInstantiate);
        }



    }

    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;

        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            Active_Sea(i);
            Active_Map(i);
            //Active_Wall(i);
        }

        //while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();

        currentTipIndex = toTipIndex;
    }

    //GameObject GenerateStage(int tipIndex)
    //{
    //    int nextStageTip = Random.Range(0, stageTips.Length);

    //    GameObject stageObject = (GameObject)Instantiate(
    //        stageTips[nextStageTip],
    //        new Vector3(tipIndex * StageTipSize, 0, 0),
    //        Quaternion.identity
    //        );

    //    return stageObject;
    //}

    //void DestroyOldestStage()
    //{
    //    GameObject oldStage = generatedStageList[0];
    //    generatedStageList.RemoveAt(0);
    //    Destroy(oldStage);
    //}

    /*
    private void OnBecameInvisible(Collider col)
    {
        gameObject.SetActive(false);
    }
    */
    void Active_Sea(int idx)
    {
        GameObject obj_Sea = StageObjPooling.current.GetPooledObject_Sea();

        if (obj_Sea == null) return;

        obj_Sea.transform.position = new Vector3(idx * StageTipSize, 0, 0);
        obj_Sea.SetActive(true);
    }

    void Active_Map(int idx)
    {
        for (int i = 1; i < 20; i++)
        {
            if (i % 3 == 0)
            {
                if (Random.value < 0.1)
                {
                    GameObject obj_Wall = StageObjPooling.current.GetPooledObject_Wall();

                    if (obj_Wall == null) return;

                    obj_Wall.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, 0);
                    obj_Wall.SetActive(true);
                }
                else if (Random.value >= 0.1 && Random.value <= 0.8)
                {
                    //GameObject obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    //GameObject obj_Obstacle_1_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    //if (obj_Obstacle_1 == null && obj_Obstacle_1_1 != null)
                    //{
                    //    obj_Obstacle_1_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(1, 3) * 10);
                    //    obj_Obstacle_1_1.SetActive(true);
                    //}
                    //else if(obj_Obstacle_1 != null && obj_Obstacle_1_1 == null)
                    //{
                    //    obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 1) * 10);
                    //    obj_Obstacle_1.SetActive(true);
                    //}
                    //else if(obj_Obstacle_1 != null && obj_Obstacle_1_1 != null)
                    //{
                    //    obj_Obstacle_1_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(1, 3) * 10);
                    //    obj_Obstacle_1_1.SetActive(true);
                    //    obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 1) * 10);
                    //    obj_Obstacle_1.SetActive(true);
                    //}

                    GameObject obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();

                    if (obj_Obstacle_1 == null) return;

                    obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 1) * 10);
                    obj_Obstacle_1.SetActive(true);

                    obj_Obstacle_1 = StageObjPooling.current.GetPooledObject_Obstacle_1();
                    if (obj_Obstacle_1 == null) return;
                    obj_Obstacle_1.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(1, 3) * 10);
                    obj_Obstacle_1.SetActive(true);
                }
                else
                {
                    GameObject obj_Obstacle_2 = StageObjPooling.current.GetPooledObject_Obstacle_2();

                    if (obj_Obstacle_2 == null) return;

                    obj_Obstacle_2.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 0, Random.Range(-2, 3) * 10);
                    obj_Obstacle_2.SetActive(true);
                }
            }
            else
            {
                GameObject obj_Coin = StageObjPooling.current.GetPooledObject_Coin();

                if (obj_Coin == null) return;

                obj_Coin.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 1, Random.Range(-2, 1) * 10);
                obj_Coin.SetActive(true);

                obj_Coin = StageObjPooling.current.GetPooledObject_Coin();
                if (obj_Coin == null) return;
                obj_Coin.transform.position = new Vector3(idx * StageTipSize - 100 + (i * 10), 1, Random.Range(1, 3) * 10);
                obj_Coin.SetActive(true);
            }
        }
    }

    //void Active_Wall(int idx)
    //{
    //    if (Random.value < 0.1)
    //    {
    //        GameObject obj_Wall = StageObjPooling.current.GetPooledObject_Wall();

    //        if (obj_Wall == null) return;

    //        obj_Wall.transform.position = new Vector3(idx * StageTipSize + (Random.Range(-10, 10) * 10), 0, 0);
    //        obj_Wall.SetActive(true);
    //    }
    //}
}

