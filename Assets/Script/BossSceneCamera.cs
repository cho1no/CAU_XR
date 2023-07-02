using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneCamera : MonoBehaviour
{
    public Transform target;          // 카메라가 따라갈 대상의 Transform
    public float smoothSpeed = 0.125f; // 카메라 이동 속도 (값이 작을수록 더 부드럽게 따라감)
    public Vector3 offset;            // 대상으로부터의 상대적인 위치 (오프셋)
    public float minX;                // 카메라가 이동 가능한 최소 X 좌표
    public float maxX;                // 카메라가 이동 가능한 최대 X 좌표
    PlayerSkills skill;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        skill = GetComponent<PlayerSkills>();
    }
    private void LateUpdate()
    {
        // 대상의 현재 위치에 오프셋을 더해 타겟 포인트를 계산
        Vector3 targetPosition = new Vector3(target.position.x + offset.x +2, 0.05f, -10) ;

        // 타겟 포인트의 X 좌표를 제한하여 카메라가 minX와 maxX 범위 내에서만 이동하도록 함
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

        // 카메라의 현재 위치에서 타겟 포인트를 향해 부드럽게 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
    //public Transform target;
    //public float speed = 3;
    //public Vector2 center;
    //public Vector2 size;
    //float height;
    //float width;

    //Vector3 NonTagetTransform = new Vector3(0, 0, 0);
    //void Start()
    //{
    //    height = Camera.main.orthographicSize;
    //    width = height * Screen.width / Screen.height;
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireCube(center, size);
    //}

    //private void LateUpdate()
    //{
    //    float lx;
    //    float clampX;
    //    if (target != null)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);//플레이어 위치를 받옴 
    //        lx = size.x * 0.5f - width;
    //        clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

    //        transform.position = new Vector3(clampX, 0, -10f);
    //    }
    //    else
    //    {

    //        transform.position = Vector3.Lerp(transform.position, NonTagetTransform, Time.deltaTime * speed);

    //    }



    //}
    //public GameObject cam;
    //bool isRight;
    //public float CameraSpeed = 10f;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    float posX = transform.position.x;
    //    float posY = transform.position.y;
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        isRight = false;
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        isRight = true;
    //    }
    //    if (isRight) { cam.gameObject.SetActive(true); cam.gameObject.SetActive(false); }
    //    else { cam.gameObject.SetActive(true); cam.gameObject.SetActive(false); }
    //}
}
