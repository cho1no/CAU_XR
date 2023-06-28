using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//국제적 어필 방법, 비즈니스모델(컨텐츠 비교분석)
public class Playeritems : MonoBehaviour
{
    public SOItem[] item;

    public Image[] imgIcon;
    public Image[] imgCool;


    //Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        for (int i = 0; i < item.Length; i++)
        {
            imgIcon[i].sprite = item[i].icon;
            imgCool[i].fillAmount = 0;
        }
    }
    private void Update()
    {
        getKey();
    }
    public void getKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnClicked(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            OnClicked(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            OnClicked(2);
        }
    }
    public void SkillActive(int i)
    {
        //if (imgCool[i].fillAmount > 0) return;

        switch (i)
        {
            case 0: //hpitem

                break;
            case 1: //iphone

                break;
            case 2: //ipad

                break;
        }

    }
    public void afterflash()
    {
        //sr.color = new Color32(255, 255, 255, 255);
        gameObject.SetActive(true);
        rb.gravityScale = 9.8f;
    }

    // 인자로 넘어온 skill 정보에 따라 애니메이션을 플레이하고
    // damage 정보 만큼 피해를 입힙니다.
    //public void ActivateSkill(item skill)
    //{
    //    //anim.Play(skill.animationName);
    //    anim.SetTrigger(skill.animationName);
    //    print(string.Format("적에게 스킬 {0} 로 {1} 의 피해를 주었습니다.", skill.name, skill.damage));
    //}
    public void OnClicked(int i)
    {
        // Cool 이미지의 fillAmount 가 0 보다 크다는 것은
        // 아직 쿨타임이 끝나지 않았다는 뜻
        if (imgCool[i].fillAmount > 0) return;

        // Player 객체의 ActivateSkill 호출
        // ActivateSkill(skill[i]);
        SkillActive(i);
        // 스킬 Cool 처리
        StartCoroutine(SC_Cool(i));
    }
    IEnumerator SC_Cool(int i)
    {
        // skill.cool 값에 따라 달라짐
        // 예: skill.cool 이 10초 라면
        // tick = 0.1
        float tick = 1f / item[i].cool;
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
