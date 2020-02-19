// dnSpy decompiler from Assembly-UnityScript-firstpass.dll class: CubeSelectScript
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class CubeSelectScript : MonoBehaviour
{
	public override void Update()
	{
		if (CubeSelectScript.startGameCount == 0)
		{
			if (MenuButtonScript.userCrossInput && MenuButtonScript.playerVsComputer)
			{
				int num = UnityEngine.Random.Range(0, 2);
				int num2 = num;
				if (num2 == 0)
				{
					CubeSelectScript.computerCircleTurn = true;
					CubeSelectScript.computerCircleTurnOnce = true;
					CubeSelectScript.playerCrossTurn = false;
				}
				else if (num2 == 1)
				{
					CubeSelectScript.playerCrossTurn = true;
				}
			}
			else if (MenuButtonScript.userCircleInput && MenuButtonScript.playerVsComputer)
			{
				int num3 = UnityEngine.Random.Range(0, 2);
				int num4 = num3;
				if (num4 == 0)
				{
					CubeSelectScript.computerCrossTurn = true;
					CubeSelectScript.computerCrossTurnOnce = true;
					CubeSelectScript.playerCircleTurn = false;
				}
				else if (num4 == 1)
				{
					CubeSelectScript.playerCircleTurn = true;
				}
			}
			CubeSelectScript.startGameCount++;
		}
		if (CubeSelectScript.computerCircleTurnOnce)
		{
			Transform transform = (Transform)UnityEngine.Object.Instantiate(this.cubePrefab, GameObject.Find("cubeSpawnPoint").transform.position, Quaternion.identity);
			this.StartCoroutine(this.ComputerCircleTurn());
			CubeSelectScript.computerCircleTurnOnce = false;
		}
		else if (CubeSelectScript.computerCrossTurnOnce)
		{
			Transform transform2 = (Transform)UnityEngine.Object.Instantiate(this.cubePrefab, GameObject.Find("cubeSpawnPoint").transform.position, Quaternion.identity);
			this.StartCoroutine(this.ComputerCrossTurn());
			CubeSelectScript.computerCrossTurnOnce = false;
		}
		if (UnityEngine.Input.GetKeyDown("escape"))
		{
			ColliderScript.tieGameCount = 0;
			ColliderScript.updatedCount = false;
			ColliderScript.playerLost = false;
			ColliderScript.playerWon = false;
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
	}

	public override void OnMouseUp()
	{
		if (!this.isUsed && MenuButtonScript.playerVsPlayer && CubeSelectScript.playerOneTurn)
		{
			this.StartCoroutine(this.PlayerOneTurn());
		}
		else if (!this.isUsed && MenuButtonScript.playerVsPlayer && CubeSelectScript.playerTwoTurn)
		{
			this.StartCoroutine(this.PlayerTwoTurn());
		}
		if (!this.isUsed && MenuButtonScript.userCrossInput && MenuButtonScript.playerVsComputer)
		{
			this.isUsed = true;
			this.PlayerCrossTurn();
		}
		else if (!this.isUsed && MenuButtonScript.userCircleInput && MenuButtonScript.playerVsComputer)
		{
			this.isUsed = true;
			this.PlayerCircleTurn();
		}
	}

	public override void PlayerCrossTurn()
	{
		if (CubeSelectScript.playerCrossTurn)
		{
			Transform transform = (Transform)UnityEngine.Object.Instantiate(this.crossPrefab, this.transform.Find("crossSpawnPoint").transform.position, Quaternion.identity);
			Transform transform2 = (Transform)UnityEngine.Object.Instantiate(this.cubePrefab, GameObject.Find("cubeSpawnPoint").transform.position, Quaternion.identity);
			CubeSelectScript.computerCircleTurn = true;
			CubeSelectScript.playerCrossTurn = false;
			this.StartCoroutine(this.ComputerCircleTurn());
		}
	}

	public override IEnumerator ComputerCircleTurn()
	{
		return new CubeSelectScript._0024ComputerCircleTurn_002414(this).GetEnumerator();
	}

	public override void PlayerCircleTurn()
	{
		if (CubeSelectScript.playerCircleTurn)
		{
			Transform transform = (Transform)UnityEngine.Object.Instantiate(this.circlePrefab, this.transform.Find("circleSpawnPoint").transform.position, Quaternion.identity);
			Transform transform2 = (Transform)UnityEngine.Object.Instantiate(this.cubePrefab, GameObject.Find("cubeSpawnPoint").transform.position, Quaternion.identity);
			CubeSelectScript.computerCrossTurn = true;
			CubeSelectScript.playerCircleTurn = false;
			this.StartCoroutine(this.ComputerCrossTurn());
		}
	}

	public override IEnumerator ComputerCrossTurn()
	{
		return new CubeSelectScript._0024ComputerCrossTurn_002420(this).GetEnumerator();
	}

	public override IEnumerator PlayerOneTurn()
	{
		return new CubeSelectScript._0024PlayerOneTurn_002426(this).GetEnumerator();
	}

	public override IEnumerator PlayerTwoTurn()
	{
		return new CubeSelectScript._0024PlayerTwoTurn_002432(this).GetEnumerator();
	}

	public override void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "circle")
		{
			this.isUsed = true;
			this.transform.Find("spawnPos").tag = "isUsed";
			ColliderScript.tieGameCount++;
		}
		else if (hit.gameObject.tag == "cross")
		{
			this.isUsed = true;
			this.transform.Find("spawnPos").tag = "isUsed";
			ColliderScript.tieGameCount++;
		}
	}

	public override void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 800f, (float)Screen.height / 480f, 1f));
		if (CubeSelectScript.playerOneTurn && MenuButtonScript.playerVsPlayer)
		{
			GUI.Box(new Rect((float)345, (float)154, (float)200, (float)25), "Cross Turn");
		}
		if (CubeSelectScript.playerTwoTurn && MenuButtonScript.playerVsPlayer)
		{
			GUI.Box(new Rect((float)345, (float)154, (float)200, (float)25), "Circle Turn");
		}
	}

	public override void Main()
	{
	}

	public Transform crossPrefab;

	public Transform circlePrefab;

	public Transform cubePrefab;

	public bool isUsed;

	[NonSerialized]
	public static int startGameCount;

	[NonSerialized]
	public static bool playerOneTurn = true;

	[NonSerialized]
	public static bool playerTwoTurn;

	[NonSerialized]
	public static bool playerCrossTurn;

	[NonSerialized]
	public static bool playerCircleTurn;

	[NonSerialized]
	public static bool computerCircleTurn;

	[NonSerialized]
	public static bool computerCrossTurn;

	[NonSerialized]
	public static bool computerCrossTurnOnce;

	[NonSerialized]
	public static bool computerCircleTurnOnce;

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024ComputerCircleTurn_002414 : GenericGenerator<WaitForSeconds>
	{
		public _0024ComputerCircleTurn_002414(CubeSelectScript self_)
		{
			this._0024self__002419 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new CubeSelectScript._0024ComputerCircleTurn_002414._0024(this._0024self__002419);
		}

		internal CubeSelectScript _0024self__002419;
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024ComputerCrossTurn_002420 : GenericGenerator<WaitForSeconds>
	{
		public _0024ComputerCrossTurn_002420(CubeSelectScript self_)
		{
			this._0024self__002425 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new CubeSelectScript._0024ComputerCrossTurn_002420._0024(this._0024self__002425);
		}

		internal CubeSelectScript _0024self__002425;
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024PlayerOneTurn_002426 : GenericGenerator<WaitForSeconds>
	{
		public _0024PlayerOneTurn_002426(CubeSelectScript self_)
		{
			this._0024self__002431 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new CubeSelectScript._0024PlayerOneTurn_002426._0024(this._0024self__002431);
		}

		internal CubeSelectScript _0024self__002431;
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024PlayerTwoTurn_002432 : GenericGenerator<WaitForSeconds>
	{
		public _0024PlayerTwoTurn_002432(CubeSelectScript self_)
		{
			this._0024self__002437 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new CubeSelectScript._0024PlayerTwoTurn_002432._0024(this._0024self__002437);
		}

		internal CubeSelectScript _0024self__002437;
	}
}
