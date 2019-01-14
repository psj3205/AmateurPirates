using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    Vector3 diff; // 카메라와 타겟 사이의 거리
    bool StartBtnClk = false;
    bool gameStart = false;

    public GameObject target; // 카메라가 따라갈 대상
    public float followSpeed;

    private Quaternion Right = Quaternion.identity;
    public float duration = 1.0f;
    private float elapsed = 0.0f;

    //Animator animator;
    // Use this for initialization
    //void Start()
    //{
    //    Camera.main.depthTextureMode = DepthTextureMode.Depth;
    //    diff = target.transform.position - transform.position;
    //    //animator = GetComponent<Animator>();
    //}

    void LateUpdate()
    {
        // 타이틀 화면에서 한번 탭하여 게임 준비상태로 진입
        if (StartBtnClk == true && gameStart == false) 
        {
            elapsed += Time.deltaTime / duration;
            Right.eulerAngles = new Vector3(39.6f, 53f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Right, Time.deltaTime * 7f);
            transform.position = Vector3.Lerp(transform.position, new Vector3(-25.6f, 27.9f, -17.9f), Time.deltaTime * 7f);
            Camera.main.orthographicSize = Mathf.Lerp(11f, 18f, elapsed);
          
            if(Camera.main.orthographicSize == 18f)
            {
                gameStart = true;
                diff = target.transform.position - transform.position;
            }
        }

        // 게임 준비상태서 탭하여 게임 시작 
        else if (gameStart == true && StartBtnClk == true)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                target.transform.position - diff,
                Time.deltaTime * followSpeed
                );
        }
    }

    public void CameraPanning()
    {
        StartBtnClk = true;
    }

    public bool CameraReady() // 카메라 회전이 완료되었는지를 리턴하는 함수
    {
        return gameStart;
    }
}
