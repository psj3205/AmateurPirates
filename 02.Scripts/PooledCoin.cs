using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledCoin : MonoBehaviour
{
    MiniGameController MiniGameController;


    //// Use this for initialization
    void Start()
    {
        MiniGameController = GameObject.FindGameObjectWithTag("MiniGameController").GetComponent<MiniGameController>();
    }

    //// Update is called once per frame
    //void Update () {

    //}

    //void OnBecameInvisible()
    //{
    //    this.gameObject.SetActive(false);
    //    Debug.Log("cameraout!!!");
    //}

    public void Score()
    {
        MiniGameController.score++;
    }

    void OnTriggerEnter(Collider collision)
    {
        //if (collision.tag == "endline")
        //{
        //    this.gameObject.SetActive(false);
        //    //Debug.Log("hit!!!");
        //}

        if (collision.CompareTag("Obstacle_endline"))
        {
            this.gameObject.SetActive(false);
            //Debug.Log("hit!!!");
        }

        //if (collision.tag == "Obstacle_endline")
        //{
        //    this.gameObject.SetActive(false);
        //    //Debug.Log("hit!!!");
        //}

        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlayCoinSound(); // 코인 효과음 재생
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            Score();
        }
        //if (collision.tag == "Player")
        //{
        //    this.gameObject.SetActive(false);
        //    this.gameObject.transform.position = new Vector3(0, 0, 0);
        //    Score();
        //}
    }
}