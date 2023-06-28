using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetMap : TutorialBase
{
    public GameObject offmap;
    public GameObject onmap;
    public GameObject Player;
    public int X;
    public int Y;
    public override void Enter()
    {

    }
    public override void Execute(TutorialController controller)
    {
        offmap.SetActive(false);
        onmap.SetActive(true);

        Player.transform.position = new Vector2(X, Y);

        controller.SetNextTutorial();
    }
    public override void Exit()
    {

    }

}
