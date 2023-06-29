using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneCamera : MonoBehaviour
{
    public GameObject[] cam;
    bool isRight;
    public float CameraSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            isRight = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = true;
        }
        if (isRight) { cam[0].gameObject.SetActive(true); cam[1].gameObject.SetActive(false); }
        else { cam[1].gameObject.SetActive(true); cam[0].gameObject.SetActive(false); }
    }
}
