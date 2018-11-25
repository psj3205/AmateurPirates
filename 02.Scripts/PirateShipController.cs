using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PirateShipController : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 10f;
    const int DefaultLife = 1;
    int life = DefaultLife;

    CharacterController controller;
    public Shooter cannonShooter;

    Vector3 moveDirection = Vector3.zero;
    public int targetLane;

    public float speedX;
    public float speedZ;
    public float accelerationX;

    //private Vector3 clickPos = Vector3.zero;
    private Touch tempTouchs;
    //private Vector3 touchedPos;
    private float screenCenter;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        screenCenter = Screen.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (life <= 0) Time.timeScale = 0; //죽으면 동작입력 안되게 정지
        if(controller.velocity.x > 0) // 타이틀화면에 방향입력 안되게 
        {
            if (Input.GetKeyDown("left")) MoveToLeft();
            if (Input.GetKeyDown("right")) MoveToRight();
            if (Input.GetKeyDown("b")) cannonShooter.Active_CannonBall(0);
        }

        //RaycastHit hit;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false) //UI 클릭시 게임플레이 안의 클릭 방지
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

            //if (Physics.Raycast(ray, out hit, 100.0f))
            //{
            //if (hit.collider.tag == "water")
            //if (hit.collider.CompareTag("water"))
            //{
            //Debug.Log("water hit!");
            //화면 기준 방향 전환
            if (Input.mousePosition.x < screenCenter)
                MoveToLeft();
            else
                MoveToRight();

            //캐릭터 기준 방향 전환
            //if(hit.point.z > transform.position.z + 5)
            //{
            //    MoveToLeft();
            //    Debug.Log(hit.point.z);
            //}
            //else if(hit.point.z < transform.position.z - 5)
            //{
            //    MoveToRight();
            //    Debug.Log(hit.point.z);
            //}
            //}
            //}
        }
#endif

#if UNITY_ANDROID
        //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (EventSystem.current.IsPointerOverGameObject(i) == false && controller.velocity.x > 5)
            {
                if (Input.touchCount == 1)
                {
                    tempTouchs = Input.GetTouch(i);
                    if (tempTouchs.phase == TouchPhase.Began)
                    {
                        //touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);
                        //Debug.Log(tempTouchs.position.x);
                        //if (Physics.Raycast(ray, out hit, 100.0f))
                        //{
                        //if (hit.collider.tag == "water")
                        //if (hit.collider.CompareTag("water"))
                        //{
                        //Debug.Log("water hit!");
                        //화면 기준 방향 전환
                        if (tempTouchs.position.x < screenCenter)
                            MoveToLeft();
                        else
                            MoveToRight();
                        //}
                        //}
                        break;
                    }
                }
                else if (Input.touchCount == 2)
                {
                    //tempTouchs = Input.GetTouch(i);
                    if (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(1).phase == TouchPhase.Began)
                    {
                        cannonShooter.Active_CannonBall(0);
                        break;
                    }
                }
            }
        }
#endif

        float acceleratedX = moveDirection.x + (accelerationX * Time.deltaTime);
        moveDirection.x = Mathf.Clamp(acceleratedX, 0, speedX);


        float ratioZ = (targetLane * LaneWidth - transform.position.z) / LaneWidth;
        moveDirection.z = ratioZ * speedZ;
        //Debug.Log(ratioZ);
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //Debug.Log(globalDirection);

        //게임오버 되어 결과창 나왔을때 방향입력 안되게
        if (life <= 0) controller.Move(Vector3.zero);
        else controller.Move(globalDirection * Time.deltaTime);



        speedX += speedX * Time.deltaTime * 0.001f;

    }

    public void MoveToRight()
    {
        SoundManager.instance.PlayMoveSound(); // 이동 효과음 재생
        if (targetLane > MinLane) targetLane--;
    }
    public void MoveToLeft()
    {
        SoundManager.instance.PlayMoveSound(); // 이동 효과음 재생
        if (targetLane < MaxLane) targetLane++;
    }

    public void start()
    {
        speedX = 30f;
    }

    public int Life()
    {
        return life;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "CannonBall" && life > 0)// 자신이 쏜 폭탄에 충돌 처리 방지
        {
            life--;
            SoundManager.instance.PlayGameoverSound(); // 게임오버 효과음 재생
        }

    }
}
