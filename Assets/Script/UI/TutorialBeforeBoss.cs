using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialBeforeBoss : TutorialBase
{
    [SerializeField]
    public PlayerController playerController;
    [SerializeField]
    public Transform[] triggerObject;
    Transform triggerObject0, triggerObject1;

    public Image img;
    public Text txt;
    public GameObject Player;
    public int X;
    public int Y;

    public bool isTrigger { set; get; } = false;

    public bool isIn { set; get; } = false;

    public override void Enter()
    {
        // �÷��̾� �̵� ����
        playerController.IsMoved = true;
        img.gameObject.SetActive(true);
        txt.gameObject.SetActive(true);
        // Trigger ������Ʈ Ȱ��ȭ
        for (int i = 0; i < triggerObject.Length; i++)
        {
            triggerObject[i].gameObject.SetActive(true);
        }
        //triggerObject0 = triggerObject[0].transform; triggerObject1 = triggerObject[1].transform;
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
                txt.text = "+";
                txt.text += BeforeBossBuff.Instance.bossBuff;
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
        //Trigger ������Ʈ ��Ȱ��ȭ
        img.gameObject.SetActive(false);
        txt.gameObject.SetActive(false);
        for (int i = 0; i < triggerObject.Length; i++)
        {
            triggerObject[i].gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.Equals(triggerObject[0])|| collision.transform.Equals(triggerObject[1]))
        {
            Debug.Log("123");
            if (BeforeBossBuff.Instance.bossBuff >= 5)
            {
                isTrigger = true;
                collision.gameObject.SetActive(false);
            }
            if (BeforeBossBuff.Instance.bossBuff < 5)
            {
                isIn = true;
            }
        }
    }
}
