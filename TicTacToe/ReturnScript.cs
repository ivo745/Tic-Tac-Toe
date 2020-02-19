// dnSpy decompiler from Assembly-UnityScript-firstpass.dll class: ReturnScript
using System;
using UnityEngine;

[Serializable]
public class ReturnScript : MonoBehaviour
{
	public override void OnMouseUp()
	{
		ColliderScript.updatedCount = false;
		ColliderScript.playerLost = false;
		ColliderScript.playerWon = false;
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	public override void Update()
	{
		if (CubeSelectScript.playerCrossTurn && MenuButtonScript.userCrossInput)
		{
			CubeSelectScript.computerCircleTurnOnce = false;
			CubeSelectScript.computerCrossTurnOnce = false;
		}
		if (CubeSelectScript.playerCircleTurn && MenuButtonScript.userCircleInput)
		{
			CubeSelectScript.computerCircleTurnOnce = false;
			CubeSelectScript.computerCrossTurnOnce = false;
		}
		if (CubeSelectScript.computerCrossTurn && MenuButtonScript.userCircleInput)
		{
			CubeSelectScript.computerCircleTurnOnce = false;
			CubeSelectScript.computerCrossTurnOnce = true;
		}
		if (CubeSelectScript.computerCircleTurn && MenuButtonScript.userCrossInput)
		{
			CubeSelectScript.computerCircleTurnOnce = true;
			CubeSelectScript.computerCrossTurnOnce = false;
		}
	}

	public override void Main()
	{
	}
}
