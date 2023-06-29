using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScaleDown : TutorialBase
{
	[SerializeField]
	private	GameObject	scaleTransform;
	private	bool			isCompleted = false;

	public override void Enter()
	{
		scaleTransform.gameObject.SetActive(true);

		StartCoroutine("TimeCheck");
	}

	public override void Execute(TutorialController controller)
	{
		scaleTransform.transform.localScale -= 20 * Vector3.one * Time.deltaTime;

		if ( isCompleted == true )
		{
			controller.SetNextTutorial();
		}
	}

	private IEnumerator TimeCheck()
	{
		yield return new WaitForSeconds(1.5f);

		isCompleted = true;
	}

	public override void Exit()
	{
		scaleTransform.gameObject.SetActive(false);
	}
}
