using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//������ ���� ���, ����Ͻ���(������ �񱳺м�)
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

    // ���ڷ� �Ѿ�� skill ������ ���� �ִϸ��̼��� �÷����ϰ�
    // damage ���� ��ŭ ���ظ� �����ϴ�.
    //public void ActivateSkill(item skill)
    //{
    //    //anim.Play(skill.animationName);
    //    anim.SetTrigger(skill.animationName);
    //    print(string.Format("������ ��ų {0} �� {1} �� ���ظ� �־����ϴ�.", skill.name, skill.damage));
    //}
    public void OnClicked(int i)
    {
        // Cool �̹����� fillAmount �� 0 ���� ũ�ٴ� ����
        // ���� ��Ÿ���� ������ �ʾҴٴ� ��
        if (imgCool[i].fillAmount > 0) return;

        // Player ��ü�� ActivateSkill ȣ��
        // ActivateSkill(skill[i]);
        SkillActive(i);
        // ��ų Cool ó��
        StartCoroutine(SC_Cool(i));
    }
    IEnumerator SC_Cool(int i)
    {
        // skill.cool ���� ���� �޶���
        // ��: skill.cool �� 10�� ���
        // tick = 0.1
        float tick = 1f / item[i].cool;
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
