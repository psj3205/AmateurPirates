using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonDown : MonoBehaviour {

    public GameObject TitleObject;
    float speed = 2.0f;
    bool down;

    // Update is called once per frame
    void Update () {
		if(down == true)
        {
             //Debug.Log("ing");
             transform.position = Vector3.MoveTowards(transform.position, new Vector3(-20.33f, -5f, 15.68f), speed * Time.deltaTime);
            if(transform.position.y == -5.0)
            {
                TitleObject.SetActive(false);
            }
        }
	}

    public void OnClickStart()
    {
        //Debug.Log("set");
        down = true;
    }

}
