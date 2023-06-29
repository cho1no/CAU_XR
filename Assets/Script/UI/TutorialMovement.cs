using System.Collections;
using UnityEngine;

public class TutorialMovement : TutorialBase
{
	[SerializeField]
	private	GameObject	rectTransform;
	[SerializeField]
	private	Vector3			endPosition;
	private	bool			isCompleted = false;

	public override void Enter()
	{
		StartCoroutine(nameof(Movement));
	}

	public override void Execute(TutorialController controller)
	{
		if ( isCompleted == true )
		{
			controller.SetNextTutorial();
		}
	}

	public override void Exit()
	{
	}

	private IEnumerator Movement()
	{
		float	current = 0;
		float	percent = 0;
		float	moveTime = 0.5f;
		Vector3	start = rectTransform.transform.position;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / moveTime;

			rectTransform.transform.position = Vector3.Lerp(start, endPosition, percent);

			yield return null;
		}

		isCompleted = true;
	}
}

