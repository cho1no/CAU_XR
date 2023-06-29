using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float detectionRange = 15f;

    private Transform playerTransform;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
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
                rb.velocity = direction.normalized * moveSpeed;
            }
            else
            {
                // �÷��̾ ���� ������ ��� ��� ����
                rb.velocity = Vector2.zero;
            }
        }
    }
}