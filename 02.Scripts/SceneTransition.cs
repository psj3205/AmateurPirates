using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.activeInHierarchy)
        {
            animator.SetBool("isOpen", true);
            StartCoroutine(ReturnToTitle(0.01f)); //IEnumerator 실행 
        }
    }

    IEnumerator ReturnToTitle(float waitTime)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0); // 처음으로 돌아가기
    }
}
