using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject cannoBallPrefab;
    //public GameObject arrowPrefab;
    //private Vector3 originPos = Vector3.zero;
    private Vector3 dir = new Vector3 (1, 0.03f, 0);
    //GameObject arrow;
    float arrowAngle;
    float shotSpeed = 3500;

    // Use this for initialization
    //void Start()
    //{
    //    //arrow = (GameObject)Instantiate(
    //    //    arrowPrefab,
    //    //    transform.position,
    //    //    Quaternion.identity
    //    //);

    //    ////Shooter오브젝트 안에 자식으로 배치
    //    //arrow.transform.SetParent(transform);
    //    //arrow.SetActive(false);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetMouseButtonDown(0))
    //    //{
    //    //    originPos = Input.mousePosition;
    //    //}
    //    //if (Vector3.Distance(originPos, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) > 40)
    //    //    OnDrag();
    //    ////Debug.Log(shotSpeed);
    //}

    //public void Shot()
    //{
    //    // 프리팹에서 CannonBall 오브젝트를 생성
    //    GameObject cannonBall = (GameObject)Instantiate(
    //        cannoBallPrefab,
    //        transform.position,
    //        Quaternion.identity
    //        );


    //}

    public void Active_CannonBall(int idx)
    {
        GameObject obj_CannonBall = StageObjPooling.current.GetPooledObject_CannonBall();

        if (obj_CannonBall == null) return;

        obj_CannonBall.transform.position = transform.position /*+ new Vector3(3f, 3f, 0)*/;
        obj_CannonBall.SetActive(true);

        // CannonBall 오브젝트의 Rigidbody를 취득하여 힘과 회전을 더한다
        Rigidbody cannonRigidBody = obj_CannonBall.GetComponent<Rigidbody>();
        //cannonRigidBody.AddForce(transform.up * shotSpeed);
        //cannonRigidBody.AddForce(new Vector3(1, 1, 0) * shotSpeed);
        cannonRigidBody.AddForce(dir * shotSpeed);
    }

    //public void OnDrag()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        arrow.SetActive(true);
    //        dir = (originPos - new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).normalized;
    //        shotSpeed = Mathf.Clamp(5 * Vector3.Distance(originPos, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), 0f, 1000.0f);
    //        arrowAngle = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

    //        arrow.transform.rotation = Quaternion.Euler(0, 0, arrowAngle);
    //        Debug.Log(arrow.transform.rotation);
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Shot();
    //        arrow.SetActive(false);
    //    }
    //}
}
