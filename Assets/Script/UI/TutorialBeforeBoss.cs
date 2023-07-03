using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBeforeBoss : TutorialBase
{
    [SerializeField]
    public PlayerController playerController;
    [SerializeField]
    public Transform[] triggerObject;


    public GameObject Player;
    public int X;
    public int Y;

    public bool isTrigger { set; get; } = false;

    public bool isIn { set; get; } = false;

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

        if (isIn)
        {
            int a = Random.Range(0, 100);
            if (a < 20)
            {
                BeforeBossBuff.Instance.SetBuff(+1);
            }
            Player.transform.position = new Vector2(X, Y);
            isIn = false;
        }
        if (isTrigger == true)
        {

            controller.SetNextTutorial();
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
            if (BeforeBossBuff.Instance.bossBuff <= 5)
            {
                isTrigger = true;
                collision.gameObject.SetActive(false);
            }
            if (BeforeBossBuff.Instance.bossBuff > 5)
            {
                isIn = true;
            }
        }
    }
}
