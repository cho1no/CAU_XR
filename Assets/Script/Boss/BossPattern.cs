using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    Animator ani;
    [SerializeField]
    private GameObject[] prefab;
    //ßbool canAttack;
    float posX, posY;
    private bool canAttack = true;
    void Start()
    {
        
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
            int pattern = Random.Range(0, 2); // 1 또는 2 중에서 랜덤으로 패턴 선택
            
            switch (pattern)
            {
                case 0:
                    ani.SetTrigger("d_cleave");
                    AttackPattern(pattern);
                    break;
                case 1:
                    ani.SetTrigger("d_smash");
                    AttackPattern(pattern);
                    break;
                case 2:
                    ani.SetTrigger("d_fire_breath");
                    AttackPattern(pattern);
                    break;
                // 추가적인 패턴이 있다면 여기에 추가
            }

            canAttack = false;
            Invoke("ResetAttack", 2f);
        }
    }
    public void AttackPattern(int i){
        switch (i){
            case 0:
                Instantiate(prefab[i], new Vector3(posX + 1, posY+0.2f, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(prefab[i], new Vector3(posX + 1, posY+0.2f, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(prefab[i], new Vector3(posX + 1, posY+0.2f, 0), Quaternion.identity);
                break;
        }
    }
    private void ResetAttack()
    {
        canAttack = true;
    }
}
