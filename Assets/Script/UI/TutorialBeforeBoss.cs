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
        // 플레이어 이동 가능
        playerController.IsMoved = true;
        // Trigger 오브젝트 활성화
        for (int i = 0; i < triggerObject.Length; i++)
        {
            triggerObject[i].gameObject.SetActive(true);
        }
    }

    public override void Execute(TutorialController controller)
    {
        /*
		/// 거리 기준
		if ( (triggerObject.position - playerController.transform.position).sqrMagnitude < 0.1f )
		{
			controller.SetNextTutorial();
		}*/

        /// 충돌 기준
        // TutorialTrigger 오브젝트의 위치를 플레이어와 동일하게 설정 (Trigger 오브젝트와 충돌할 수 있도록)
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
        // 플레이어 이동 불가능
        //playerController.IsMoved = false;
        // Trigger 오브젝트 비활성화
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
