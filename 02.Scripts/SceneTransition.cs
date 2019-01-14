using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // 씬 전환 오브젝트가 활성화 되면
        if (this.gameObject.activeInHierarchy)
        {
            animator.SetBool("isOpen", true);
            StartCoroutine(ReturnToTitle(0.01f)); //IEnumerator 실행 
        }
    }

    // 타이틀 화면으로 이동
    IEnumerator ReturnToTitle(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1); // 처음으로 돌아가기
    }
}
