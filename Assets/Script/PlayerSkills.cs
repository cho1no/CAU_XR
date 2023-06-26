using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public SOSkill[] skill;
    //public GameObject[] skills;
    public Image[] imgIcon;
    public Image[] imgCool;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnClicked(0);
            //Flash();
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
        switch (i)
        {
            case 0: //Flash
                gameObject.transform.Translate(new Vector2(this.gameObject.transform.position.x + 10, 0));
                break;
        }
        
    }


    // 인자로 넘어온 skill 정보에 따라 애니메이션을 플레이하고
    // damage 정보 만큼 피해를 입힙니다.
    public void ActivateSkill(SOSkill skill)
    {
        anim.Play(skill.animationName);
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
