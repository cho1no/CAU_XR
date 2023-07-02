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
    //SpriteRenderer spriteRenderer;
    private bool canAttack = true;
    void Start()
    {
        controller = GetComponent<BossController>();
    }
    void Awake(){
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        pattern();
    }
    public void pattern(){
        if (canAttack)
        {
            int pattern = Random.Range(0, 100); // 1 또는 2 중에서 랜덤으로 패턴 선택
            controller.isMove = false;
            switch (pattern)
            {
                case int n when (0 <= pattern && pattern < 30):
                    ani.SetTrigger("d_cleave");
                    //AttackPattern(pattern);
                    break;
                case int n when (30 <= pattern && pattern < 50):
                    ani.SetTrigger("d_smash");
                    //AttackPattern(pattern);
                    break;
                case int n when (50 <= pattern && pattern < 60):
                    ani.SetTrigger("d_fire_breath");
                    //AttackPattern(pattern);
                    break;
                case int n when (60 <= pattern && pattern < 61):
                    ani.SetTrigger("d_cast_spell");
                    AttackPattern(80);
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
                //Instantiate(prefab[i], new Vector3(posX - 1, posY, 0), Quaternion.identity);
                break;
            case int n when (40 <= i && i < 60):
                //Instantiate(prefab[i], new Vector3(posX - 1, posY, 0), Quaternion.identity);
                break;
            case int n when (60 <= i && i < 70):
                //Instantiate(prefab[i], new Vector3(posX - 1, posY, 0), Quaternion.identity);
                break;
            case int n when (70 <= i && i < 80):
                //Instantiate(prefab[i], new Vector3(posX - 1, posY, 0), Quaternion.identity);
                break;
            case int n when (80 <= i && i < 90):
                Instantiate(prefab[0], new Vector3(posX - 1, posY -3, 0), Quaternion.identity);
                break;
            case int n when (90 <= i && i < 100):
                Instantiate(prefab[1], new Vector3(posX - 1, posY - 2, 0), Quaternion.identity);
                break;
                // 추가적인 패턴이 있다면 여기에 추가
        }

    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
