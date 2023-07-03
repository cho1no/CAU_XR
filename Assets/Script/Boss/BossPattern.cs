using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    Animator ani;
    [SerializeField]
    private GameObject[] prefab;
    //ßbool canAttack;
    BossController controller;
    float posX, posY;
    //bool isLeft, isRight;
    SpriteRenderer sr;
    private bool canAttack = true;
    void Start()
    {
        controller = GetComponent<BossController>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Awake(){
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        pattern();
    }
    public void pattern(){
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y;
        if (canAttack)
        {
            int pattern = Random.Range(60, 60); // 1 또는 2 중에서 랜덤으로 패턴 선택
            controller.isMove = false;
            switch (pattern)
            {
                case int n when (0 <= pattern && pattern < 30):
                    ani.SetTrigger("d_cleave");
                    AttackPattern(20);
                    break;
                case int n when (30 <= pattern && pattern < 50):
                    ani.SetTrigger("d_smash");
                    AttackPattern(50);
                    break;
                case int n when (50 <= pattern && pattern < 60):
                    ani.SetTrigger("d_fire_breath");
                    AttackPattern(20);
                    break;
                case int n when (60 <= pattern && pattern < 61):
                    ani.SetTrigger("d_cast_spell");
                    AttackPattern(65);
                    break;
                case int n when (61 <= pattern && pattern < 100):
                    ani.SetTrigger("d_smash");
                    AttackPattern(95);
                    break;
                    // 추가적인 패턴이 있다면 여기에 추가
            }
            
            canAttack = false;
            Invoke("aMove", 4);
            Invoke("ResetAttack", 5f);
        }
    }
    private void aMove()
    {
        controller.isMove = true;
    }

    public void AttackPattern(int i){
        switch (i)
        {
            case int n when (0 <= i && i < 40):
                StartCoroutine(Smash());
                break;
            case int n when (40 <= i && i < 60):
                StartCoroutine(Jump());
                break;
            case int n when (60 <= i && i < 70): //사용 X
                StartCoroutine(Shot());
                break;
            case int n when (70 <= i && i < 80):
                StartCoroutine(Shot());
                //Instantiate(prefab[i], new Vector3(posX - 1, posY, 0), Quaternion.identity);
                break;
            case int n when (80 <= i && i < 90):
                Instantiate(prefab[0], new Vector3(posX - 1, posY -3, 0), Quaternion.identity);
                break;
            case int n when (90 <= i && i < 100):
                if (!sr.flipX)
                    StartCoroutine(Meteor(-1));
                if (sr.flipY)
                    StartCoroutine(Meteor(+1));
                break;
                // 추가적인 패턴이 있다면 여기에 추가
        }

    }
    IEnumerator Smash()
    {
        yield return new WaitForSeconds(0.5f);
        if (!sr.flipX)
            Instantiate(prefab[0], new Vector3(posX - 1, posY, 0), Quaternion.identity);
        if (sr.flipX)
            Instantiate(prefab[0], new Vector3(posX + 1, posY, 0), Quaternion.identity);
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(prefab[1], new Vector3(posX, -3, 0), Quaternion.identity);
    }
    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.5f);
        if (!sr.flipX)
        {
            prefab[2].GetComponent<MoveBall>().dir = 1;
            Instantiate(prefab[2], new Vector3(posX - 3, posY - 0.7f, 0), Quaternion.identity);
        }
        if (sr.flipX)
        {
            prefab[2].GetComponent<MoveBall>().dir = -1;
            Instantiate(prefab[2], new Vector3(posX + 3, posY - 0.7f, 0), Quaternion.identity);
        }
        
    }
    IEnumerator Meteor(int i)
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(prefab[4], new Vector3(posX + i, posY - 2, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(prefab[5], new Vector3(posX + i, posY - 2, 0), Quaternion.identity);
    }
    private void ResetAttack()
    {
        canAttack = true;
    }
}
