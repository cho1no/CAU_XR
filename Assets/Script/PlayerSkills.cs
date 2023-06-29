using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//국제적 어필 방법, 비즈니스모델(컨텐츠 비교분석)
public class PlayerSkills : MonoBehaviour
{
    public GameObject[] Effect;
    public SOSkill[] skill;
    
    //public GameObject[] skills;
    public Image[] imgIcon;
    public Image[] imgCool;

    public GameObject IPAD;

    bool isLeft; bool isRight;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        for (int i = 0; i < skill.Length; i++)
        {
            imgIcon[i].sprite = skill[i].icon;
            imgCool[i].fillAmount = 0;
        }
    }
    private void Update()
    {
        getKey();
    }
    public void getKey()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            OnClicked(0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            OnClicked(1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            OnClicked(2);
        }
        if (Input.GetKey(KeyCode.R))
        {
            OnClicked(3);
        }
    }
    public void SkillActive(int i)
    {
        //if (imgCool[i].fillAmount > 0) return;
        float posX = this.gameObject.transform.position.x;
        float posY = this.gameObject.transform.position.y;
        if (Input.GetKey(KeyCode.RightArrow)) { 
            isRight = true; isLeft = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isLeft = true; isRight = false;
        }
        switch (i)
        {
            case 0: //Flash
                Instantiate(Effect[0], new Vector3(posX, posY, 0), Quaternion.identity);
                //if (Input.GetKey(KeyCode.RightArrow))
                //    rb.AddForce(new Vector2(posX + 15, posY + 0.2f));
                //else if (Input.GetKey(KeyCode.UpArrow))
                //    rb.AddForce(new Vector2(posX, posY + 10f));
                //if (Input.GetKey(KeyCode.LeftArrow))
                //    rb.AddForce(new Vector2(posX - 15, posY + 0.2f));
                //else if (Input.GetKey(KeyCode.UpArrow))
                //    rb.AddForce(new Vector2(posX, posY + 10f));

                if (Input.GetKey(KeyCode.RightArrow))
                    gameObject.transform.position =(new Vector3(posX + 5, posY + 0.2f, 0));
                else if (Input.GetKey(KeyCode.UpArrow))
                    gameObject.transform.position = (new Vector3(posX, posY + 3.2f, 0));
                if (Input.GetKey(KeyCode.LeftArrow))
                    gameObject.transform.position = (new Vector3(posX - 5, posY + 0.2f, 0));
                else if (Input.GetKey(KeyCode.UpArrow))
                    gameObject.transform.position = (new Vector3(posX, posY + 3.2f, 0));
                rb.gravityScale = 0;
                sr.color = new Color32(255, 255, 255, 0);
                //gameObject.SetActive(false);
                float posX1 = this.gameObject.transform.position.x;
                float posY1 = this.gameObject.transform.position.y;
                Instantiate(Effect[1], new Vector3(posX1, posY1 + 1.5f, 0), Quaternion.identity);
                Invoke("afterflash", 0.4f); //StartCoroutine("aftFlash");
                //StopCoroutine("aftFlash");
                break;
            case 1:
                Instantiate(Effect[2], new Vector3(posX + 1, posY+0.2f, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(Effect[3], new Vector3(posX + 8, posY + 4f, 0), Quaternion.identity);
                break;
            case 3:
                IPAD.SetActive(true);
                StartCoroutine(aftFlash());
                StopCoroutine(aftFlash());
                break;
        }
        
    }
    public void afterflash()
    {
        sr.color = new Color32(255, 255, 255, 255);
        //gameObject.SetActive(true);
        rb.gravityScale = 9.8f;
    }
    IEnumerator aftFlash()
    {
        yield return new WaitForSeconds(2.0f);
        IPAD.SetActive(false);
        yield return new WaitForSeconds(1f);
    }


    // 인자로 넘어온 skill 정보에 따라 애니메이션을 플레이하고
    // damage 정보 만큼 피해를 입힙니다.
    public void ActivateSkill(SOSkill skill)
    {
        //anim.Play(skill.animationName);
        anim.SetTrigger(skill.animationName);
        print(string.Format("적에게 스킬 {0} 로 {1} 의 피해를 주었습니다.", skill.name, skill.damage));
    }
    public void OnClicked(int i)
    {
        // Cool 이미지의 fillAmount 가 0 보다 크다는 것은
        // 아직 쿨타임이 끝나지 않았다는 뜻
        if (imgCool[i].fillAmount > 0) return;

        // Player 객체의 ActivateSkill 호출     
        ActivateSkill(skill[i]);
        SkillActive(i);
        // 스킬 Cool 처리
        StartCoroutine(SC_Cool(i));
    }
    IEnumerator SC_Cool(int i)
    {
        // skill.cool 값에 따라 달라짐
        // 예: skill.cool 이 10초 라면
        // tick = 0.1
        float tick = 1f / skill[i].cool;
        float t = 0;

        imgCool[i].fillAmount = 1;

        // 10초에 걸쳐 1 -> 0 으로 변경하는 값을
        // imgCool.fillAmout 에 넣어주는 코드
        while (imgCool[i].fillAmount > 0)
        {
            imgCool[i].fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }
    }

}
