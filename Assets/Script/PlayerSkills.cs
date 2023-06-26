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


    // ���ڷ� �Ѿ�� skill ������ ���� �ִϸ��̼��� �÷����ϰ�
    // damage ���� ��ŭ ���ظ� �����ϴ�.
    public void ActivateSkill(SOSkill skill)
    {
        anim.Play(skill.animationName);
        print(string.Format("������ ��ų {0} �� {1} �� ���ظ� �־����ϴ�.", skill.name, skill.damage));
    }
    public void OnClicked(int i)
    {
        // Cool �̹����� fillAmount �� 0 ���� ũ�ٴ� ����
        // ���� ��Ÿ���� ������ �ʾҴٴ� ��
        if (imgCool[i].fillAmount > 0) return;

        // Player ��ü�� ActivateSkill ȣ��     
        ActivateSkill(skill[i]);
        SkillActive(i);
        // ��ų Cool ó��
        StartCoroutine(SC_Cool(i));
    }
    IEnumerator SC_Cool(int i)
    {
        // skill.cool ���� ���� �޶���
        // ��: skill.cool �� 10�� ���
        // tick = 0.1
        float tick = 1f / skill[i].cool;
        float t = 0;

        imgCool[i].fillAmount = 1;

        // 10�ʿ� ���� 1 -> 0 ���� �����ϴ� ����
        // imgCool.fillAmout �� �־��ִ� �ڵ�
        while (imgCool[i].fillAmount > 0)
        {
            imgCool[i].fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }
    }

}
