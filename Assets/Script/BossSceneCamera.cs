using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneCamera : MonoBehaviour
{
    public Transform target;          // ī�޶� ���� ����� Transform
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ� (���� �������� �� �ε巴�� ����)
    public Vector3 offset;            // ������κ����� ������� ��ġ (������)
    public float minX;                // ī�޶� �̵� ������ �ּ� X ��ǥ
    public float maxX;                // ī�޶� �̵� ������ �ִ� X ��ǥ
    PlayerSkills skill;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        skill = GetComponent<PlayerSkills>();
    }
    private void LateUpdate()
    {
        // ����� ���� ��ġ�� �������� ���� Ÿ�� ����Ʈ�� ���
        Vector3 targetPosition = new Vector3(target.position.x + offset.x +2, 0.05f, -10) ;

        // Ÿ�� ����Ʈ�� X ��ǥ�� �����Ͽ� ī�޶� minX�� maxX ���� �������� �̵��ϵ��� ��
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

        // ī�޶��� ���� ��ġ���� Ÿ�� ����Ʈ�� ���� �ε巴�� �̵�
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
    //        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);//�÷��̾� ��ġ�� �޿� 
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
