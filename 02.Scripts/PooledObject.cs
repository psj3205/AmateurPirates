using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}

    //void OnBecameInvisible()
    //{
    //    this.gameObject.SetActive(false);
    //    Debug.Log("cameraout!!!");
    //}
    void OnTriggerEnter(Collider collision)
    {
        //if (collision.tag == "endline")
        //{
        //    this.gameObject.SetActive(false);
        //    //Debug.Log("hit!!!");
        //}

        //if (collision.tag == "Obstacle_endline")
        //{
        //    this.gameObject.SetActive(false);
        //    //Debug.Log("hit!!!");
        //}
        if(collision.CompareTag("Obstacle_endline")){
            this.gameObject.SetActive(false);
        }

        if (collision.CompareTag("water"))
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = new Vector3(0, 0, 0);

            Rigidbody cannonRigidBody = GetComponent<Rigidbody>();
            cannonRigidBody.velocity = Vector3.zero;
            //Debug.Log("hit!!!");
        }
        //if (collision.tag == "water")
        //{
        //    this.gameObject.SetActive(false);
        //    this.gameObject.transform.position = new Vector3(0, 0, 0);

        //    Rigidbody cannonRigidBody = GetComponent<Rigidbody>();
        //    cannonRigidBody.velocity = Vector3.zero;
        //    //Debug.Log("hit!!!");
        //}
    }
}
