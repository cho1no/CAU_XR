using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 10;
    float jumpForce = 30;
    bool isJump;
    public bool IsMoved { set; get; } = false;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move() //플레이어 이동
    {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-playerSpeed * Time.deltaTime, 0));
                spriteRenderer.flipX = true;
                ani.SetBool("isRun", true);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector2(playerSpeed * Time.deltaTime, 0));
                spriteRenderer.flipX = false;
                ani.SetBool("isRun", true);
            }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) { ani.SetBool("isRun", false); IsMoved = false; }
    }
    void Jump()
    {

            if (Input.GetKey(KeyCode.Space))
            {
                if (!isJump)
                {
                    isJump = true;
                    rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    //ani.SetTrigger("doJump");
                }
                //transform.Translate(new Vector2(0, jumpForce * Time.deltaTime));
            }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Wall"))
        {
            isJump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            PlayerHp.Instance.SetHp(-50);
        }
    }
}
