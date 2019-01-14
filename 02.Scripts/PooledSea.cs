using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledSea : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        // 카메라 범위를 지나갈 경우 
        if (collision.CompareTag("endline")) this.gameObject.SetActive(false);
    }
}
