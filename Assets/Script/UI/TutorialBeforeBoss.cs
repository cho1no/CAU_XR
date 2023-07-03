using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBeforeBoss : TutorialBase
{
    [SerializeField]
    public PlayerController playerController;
    [SerializeField]
    public Transform[] triggerObject;

    public bool isTrigger { set; get; } = false;

    public override void Enter()
    {
        // �÷��̾� �̵� ����
        playerController.IsMoved = true;
        // Trigger ������Ʈ Ȱ��ȭ
        for (int i = 0; i < triggerObject.Length; i++)
        {
            triggerObject[i].gameObject.SetActive(true);
        }
    }

    public override void Execute(TutorialController controller)
    {
        /*
		/// �Ÿ� ����
		if ( (triggerObject.position - playerController.transform.position).sqrMagnitude < 0.1f )
		{
			controller.SetNextTutorial();
		}*/

        /// �浹 ����
        // TutorialTrigger ������Ʈ�� ��ġ�� �÷��̾�� �����ϰ� ���� (Trigger ������Ʈ�� �浹�� �� �ֵ���)
        gameObject.transform.position = playerController.transform.position;

        if (isTrigger == true)
        {
            int a = Random.Range(0, 100);
            if (a < 20)
            {
                BeforeBossBuff.Instance.SetBuff(+1);
            }
            //controller.SetNextTutorial();
        }
    }

    public override void Exit()
    {
        // �÷��̾� �̵� �Ұ���
        //playerController.IsMoved = false;
        // Trigger ������Ʈ ��Ȱ��ȭ
        for (int i = 0; i < triggerObject.Length; i++)
        {
            triggerObject[i].gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.Equals(triggerObject))
        {
            isTrigger = true;

            collision.gameObject.SetActive(false);
        }
    }
}
