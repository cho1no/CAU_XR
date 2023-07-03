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

    }

    public override void Execute(TutorialController controller)
    {
        if (isTrigger)
        {
            controller.SetNextTutorial();
        }
    }

        
    public override void Exit()
    {
    }

    public void IsTrigger()
    {
        isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.Equals("NormalShot"))
        {
            Invoke("IsTrigger", 1f);
        }
    }
}
