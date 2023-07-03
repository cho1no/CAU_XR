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
        if (playerTransform != null)
        {
            
            // 플레이어와 몬스터 사이의 거리 계산
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionRange)
            {
                float a = playerTransform.position.x - transform.position.x;
                // 플레이어를 추적하여 이동
                
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
                // 플레이어가 감지 범위를 벗어날 경우 멈춤
                rb.velocity = Vector2.zero;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("WaterShot"))
        {

            if (BossGuard.Instance.bossGuard > 0)
            {
                BossGuard.Instance.SetGuard(-1);
                ani.SetTrigger("boss_hit");
            }
            if (BossGuard.Instance.bossGuard < 1)
            {
                if (BossHp.Instance.bossHp > 150)
                {
                    ani.SetTrigger("BossDead");
                    ani.SetBool("BossAlive", true);
                }
            }
        }
        
        if (collision.gameObject.tag.Equals("WaterShot") || collision.gameObject.tag.Equals("NormalShot"))
        {
            if (BossGuard.Instance.bossGuard < 1)
            {
                BossHp.Instance.SetHp(-30);
                ani.SetTrigger("boss_hit");
                if (BossHp.Instance.bossHp <= 0)
                {
                    ani.SetBool("BossAlive", false);
                    ani.SetTrigger("BossDead");
                    Invoke("Die", 1f);
                    //Destroy(gameObject);
                }
            }
        }
        if (collision.gameObject.tag.Equals("Thunder"))
        {
            if (BossGuard.Instance.bossGuard < 1)
            {
                BossHp.Instance.SetHp(-50);
                ani.SetTrigger("boss_hit");
                if (BossHp.Instance.bossHp <= 0)
                {
                    ani.SetBool("BossAlive", false);
                    ani.SetTrigger("BossDead");
                    Invoke("Die", 1f);
                    //Destroy(gameObject);
                }
            }
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}