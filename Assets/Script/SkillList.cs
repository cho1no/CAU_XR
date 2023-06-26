using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillList : MonoBehaviour
{
    // ScriptableObject �� ������ ��ų
    public SOSkill skill;

    // Player ��ü ����
    public PlayerSkills player;

    // ��ų �̹���
    public Image imgIcon;

    // Cooldown �̹���
    public Image imgCool;

    void Start()
    {
        // SO Skill �� ����� ��ų ������ ����
        imgIcon.sprite = skill.icon;

        // Cool �̹��� �ʱ� ����
        imgCool.fillAmount = 0;
    }

    public void OnClicked()
    {
        // Cool �̹����� fillAmount �� 0 ���� ũ�ٴ� ����
        // ���� ��Ÿ���� ������ �ʾҴٴ� ��
        if (imgCool.fillAmount > 0) return;

        // Player ��ü�� ActivateSkill ȣ��     
        player.ActivateSkill(skill);

        // ��ų Cool ó��
        StartCoroutine(SC_Cool());
    }

    IEnumerator SC_Cool()
    {
        // skill.cool ���� ���� �޶���
        // ��: skill.cool �� 10�� ���
        // tick = 0.1
        float tick = 1f / skill.cool;
        float t = 0;

        imgCool.fillAmount = 1;

        // 10�ʿ� ���� 1 -> 0 ���� �����ϴ� ����
        // imgCool.fillAmout �� �־��ִ� �ڵ�
        while (imgCool.fillAmount > 0)
        {
            imgCool.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }
    }
}
