using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindAfter : TutorialBase
{
    //[SerializeField]
    //public Transform triggerObject;

    public bool isTrigger { set; get; } = false;

    public override void Enter()
    {
        // Trigger ������Ʈ Ȱ��ȭ
        //triggerObject.gameObject.SetActive(true);
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

        if (isTrigger == true)
        {
            StartCoroutine(goNext(controller));
        }
    }
    IEnumerator goNext(TutorialController controller)
    {
        yield return new WaitForSeconds(1f);
        controller.SetNextTutorial();
    }
    public override void Exit()
    {
        // Trigger ������Ʈ ��Ȱ��ȭ
        //triggerObject.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.Equals("NormalShot"))
        {
            isTrigger = true;

            //collision.gameObject.SetActive(false);
        }
    }
}
