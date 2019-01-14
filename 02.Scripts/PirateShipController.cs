using GooglePlayGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PirateShipController : MonoBehaviour
{
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 10f;
    const int DefaultLife = 1;
    int life = DefaultLife;
    float gravity = -250f;
    int jumpIdx = 0;

    CharacterController controller;
    //public Shooter cannonShooter;

    //GameObject obj_CrashEffect;

    Vector3 moveDirection = Vector3.zero;
    public int targetLane; // 이동 목표 레인

    public float speedX; // 좌우 속도
    public float speedZ; // 직진 속도
    public float speedY; // 점프 속도
    public float jumpPower = 5f;
    public float accelerationX;

    private Touch tempTouchs;
    private float screenCenter; // 화면 터치 기준

    public GameObject AnimalPanel; // 동물 획득 안내창
    Text animalText;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animalText = AnimalPanel.GetComponentInChildren<Text>(); // 동물 안내창의 text 컴포넌트 
        screenCenter = Screen.width * 0.33f; // 화면을 3등분 
    }

    void Update()
    {
        //if (life <= 0) Time.timeScale = 0; //죽으면 동작입력 안되게 정지
        if (Input.GetKeyDown("left") && controller.isGrounded) MoveToLeft();
        if (Input.GetKeyDown("right") && controller.isGrounded) MoveToRight();
        //if (Input.GetKeyDown("b")) cannonShooter.Active_CannonBall();
        if (Input.GetKeyDown("space")) Jump();

        //RaycastHit hit;

        // 에디터에서 터치
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false) //UI 클릭시 게임플레이 안의 클릭 방지
        {
            // 화면 왼쪽 눌렀을 시
            if (Input.mousePosition.x < screenCenter) MoveToLeft(); // 왼쪽으로 1칸 이동
            // 화면 가운데 눌렀을 시
            else if (Input.mousePosition.x > screenCenter && Input.mousePosition.x < screenCenter * 2) Jump(); // 점프
            // 화면 오른쪽 눌렀을 시
            else MoveToRight(); // 오른쪽으로 1칸 이동
        }
#endif
        // 안드로이드에서 터치
#if UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (EventSystem.current.IsPointerOverGameObject(i) == false && controller.velocity.x > 5)
            {
                if (Input.touchCount == 1)
                {
                    tempTouchs = Input.GetTouch(i);
                    if (tempTouchs.phase == TouchPhase.Began)
                    {
                        // 화면 왼쪽 눌렀을 시
                        if (Input.mousePosition.x < screenCenter) MoveToLeft(); // 왼쪽으로 1칸 이동
                        // 화면 가운데 눌렀을 시                            
                        else if (Input.mousePosition.x > screenCenter && Input.mousePosition.x < screenCenter * 2) Jump(); // 점프
                        // 화면 오른쪽 눌렀을 시
                        else MoveToRight(); // 오른쪽으로 1칸 이동
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
        Vector3 globalDirection = transform.TransformDirection(moveDirection);

        //게임오버 되어 결과창 나왔을때 방향입력 안되게
        if (life <= 0) controller.Move(Vector3.zero);
        else
        {
            controller.Move(globalDirection * Time.deltaTime);
            moveDirection.y = speedY;
            speedY += gravity * Time.deltaTime;
            speedX += speedX * Time.deltaTime * 0.005f;
        }

        // 속력 UI 표시
        MiniGameController.instance.velocityLabel.text = "Speed " + speedX.ToString("N1");

        if (controller.isGrounded) jumpIdx = 0; // 물로 착지하면 점프 횟수 초기화
    }

    // 점프 함수
    private void Jump()
    {
        if (controller.isGrounded) // 물 위에 있을 때 
        {
            if (MiniGameController.instance.getScore() > 0) // 코인이 있을 때만 점프가능
            {
                SoundManager.instance.PlayJumpSound();
                speedY = jumpPower;
                MiniGameController.instance.Score(-1); // 점프하면 코인 1감소
                jumpIdx++;
            }
        }

        else if (jumpIdx < 1 /*&& controller.velocity.y < 0*/)  // 공중에 있을 때
        {
            if (MiniGameController.instance.getScore() > 0) // 코인이 있을 때만 점프가능
            {
                SoundManager.instance.PlayJumpSound();
                speedY = jumpPower;
                MiniGameController.instance.Score(-1); // 점프하면 코인 1감소
                jumpIdx++;
            }
        }
    }

    // 오른쪽 이동 함수
    public void MoveToRight()
    {
        if (controller.transform.position.x > 0) // 타이틀화면에 방향입력 안되게 
        {
            SoundManager.instance.PlayMoveSound(); // 이동 효과음 재생
            if (targetLane > MinLane) targetLane--;
        }
    }

    // 왼쪽 이동 함수
    public void MoveToLeft()
    {
        if (controller.transform.position.x > 0) // 타이틀화면에 방향입력 안되게 
        {
            SoundManager.instance.PlayMoveSound(); // 이동 효과음 재생
            if (targetLane < MaxLane) targetLane++;
        }

    }

    // 시작 함수
    public void start()
    {
        speedX = 30f;
    }

    // 에너지 반환 함수
    public int Life()
    {
        return life;
    }

    // 충돌 처리
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("water") && !hit.gameObject.CompareTag("CannonBall") && life > 0)// 자신이 쏜 폭탄에 충돌 처리 방지
        {
            life--;
            //StartCoroutine(CrashEffectPlay());
            SoundManager.instance.PlayGameoverSound(); // 게임오버 효과음 재생
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("enemy"))  // 적 배에 부딪첬을 때 
        {
            life--;
            SoundManager.instance.PlayGameoverSound(); // 게임오버 효과음 재생
        }

#if UNITY_ANDROID
        // 동물 획득시
        if (other.CompareTag("Grampus")) // 범고래 획득시 업적 추가
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement__10, 1, null);

        else if (other.CompareTag("Whale")) // 향유고래 획득시 업적 추가
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement__20, 1, null);

        else if (other.CompareTag("HammerHead")) // 귀상어 획득시 업적 추가
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement__30, 1, null);
#endif

        // 동물 획득시 텍스트 표시
        if (other.CompareTag("Grampus")) // 범고래 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("범고래 발견!"));

        else if (other.CompareTag("Whale")) // 향유고래 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("향유고래 발견!"));

        else if (other.CompareTag("HammerHead")) // 귀상어 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("귀상어 발견!"));

        else if (other.CompareTag("Turtle")) // 바다거북 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("바다거북 발견!"));

        else if (other.CompareTag("Swordfish")) // 황새치 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("황새치 발견!"));

        else if (other.CompareTag("Shark_1")) // 상어 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("상어 발견!"));

        else if (other.CompareTag("WhaleShark")) // 고래상어 획득시 텍스트 표시
            StartCoroutine(AnimalTextDisplay("고래상어 발견!"));
    }

    // 동물 획득 텍스트 코루틴
    IEnumerator AnimalTextDisplay(string animal)
    {
        AnimalPanel.SetActive(true);  // 동물 이름 패널 활성화
        animalText.text = animal;     // 해당 동물 이름 입력
        yield return new WaitForSeconds(1f);
        animalText.text = "";
        AnimalPanel.SetActive(false); // 동물 이름 패널 비활성화
    }

    //IEnumerator CrashEffectPlay()
    //{
    //    obj_CrashEffect = StageObjPooling.current.GetPooledObject_CrashEffect();

    //    if (obj_CrashEffect != null)
    //    {
    //        obj_CrashEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //        obj_CrashEffect.SetActive(true);
    //        CrashEffect.instance.CrashEffectPlay();
    //    }

    //    yield return new WaitForSeconds(0.5f);
    //}
}
