using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float detectionRange = 15f;

    private Transform playerTransform;
    private Rigidbody2D rb;
    Animator ani;
    SpriteRenderer spriteRenderer;
    BossGuard bG;
    public bool isMove;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        //bG = GetComponent<BossGuard>();
    }

    private void Update()
    {
        if (isMove) ani.SetBool("d_walk", true);
        if (!isMove) ani.SetBool("d_walk", false);
        if (!isMove) Debug.Log("d");
        if (playerTransform != null)
        {
            
            // �÷��̾�� ���� ������ �Ÿ� ���
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionRange)
            {
                float a = playerTransform.position.x - transform.position.x;
                // �÷��̾ �����Ͽ� �̵�
                
                Vector2 direction = new Vector2(a, 0);
                if (a < 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                if (isMove)
                    rb.velocity = direction.normalized * moveSpeed;
            }
            else
            {
                // �÷��̾ ���� ������ ��� ��� ����
                rb.velocity = Vector2.zero;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("WaterShot"))
        {
            BossGuard.Instance.SetGuard(-1);
        }
    }
}