using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSoundPlay : TutorialBase
{
    [SerializeField]
    private AudioSource audioBoom;
    public override void Enter()
    {
        audioBoom.Play();
    }

    public override void Execute(TutorialController controller)
    {
        controller.SetNextTutorial();
    }


    public override void Exit()
    {
    }
}
