// dnSpy decompiler from Assembly-UnityScript-firstpass.dll class: ColliderScript
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ColliderScript : MonoBehaviour
{
	public override void Update()
	{
		if (MenuButtonScript.userCrossInput && MenuButtonScript.playerVsComputer)
		{
			if (this.crossCount == 3 && !ColliderScript.updatedCount)
			{
				ColliderScript.playerWon = true;
				this.StartCoroutine(this.PWon());
				ScoreScript.pScoreCount++;
				Transform transform = (Transform)UnityEngine.Object.Instantiate(this.collisionPrefab, GameObject.Find("collisionSpawnPoint").transform.position, Quaternion.identity);
				CubeSelectScript.playerCrossTurn = false;
				CubeSelectScript.computerCircleTurn = true;
				ColliderScript.tieGameCount = 0;
				ColliderScript.updatedCount = true;
			}
			else if (this.circleCount == 3 && !ColliderScript.updatedCount)
			{
				ColliderScript.playerLost = true;
				this.StartCoroutine(this.PLost());
				ScoreScript.cScoreCount++;
				Transform transform2 = (Transform)UnityEngine.Object.Instantiate(this.collisionPrefab, GameObject.Find("collisionSpawnPoint").transform.position, Quaternion.identity);
				CubeSelectScript.playerCrossTurn = true;
				CubeSelectScript.computerCircleTurn = false;
				ColliderScript.tieGameCount = 0;
				ColliderScript.updatedCount = true;
			}
		}
		else if (MenuButtonScript.userCircleInput && MenuButtonScript.playerVsComputer)
		{
			if (this.circleCount == 3 && !ColliderScript.updatedCount)
			{
				ColliderScript.playerWon = true;
				this.StartCoroutine(this.PWon());
				ScoreScript.pScoreCount++;
				Transform transform3 = (Transform)UnityEngine.Object.Instantiate(this.collisionPrefab, GameObject.Find("collisionSpawnPoint").transform.position, Quaternion.identity);
				CubeSelectScript.playerCircleTurn = false;
				CubeSelectScript.computerCrossTurn = true;
				ColliderScript.tieGameCount = 0;
				ColliderScript.updatedCount = true;
			}
			else if (this.crossCount == 3 && !ColliderScript.updatedCount)
			{
				ColliderScript.playerLost = true;
				this.StartCoroutine(this.PLost());
				ScoreScript.cScoreCount++;
				Transform transform4 = (Transform)UnityEngine.Object.Instantiate(this.collisionPrefab, GameObject.Find("collisionSpawnPoint").transform.position, Quaternion.identity);
				CubeSelectScript.playerCircleTurn = true;
				CubeSelectScript.computerCrossTurn = false;
				ColliderScript.tieGameCount = 0;
				ColliderScript.updatedCount = true;
			}
		}
		if (MenuButtonScript.userCrossInput && MenuButtonScript.playerVsPlayer)
		{
			if (this.crossCount == 3 && !ColliderScript.updatedCount)
			{
				this.StartCoroutine(this.P1Won());
				ScoreScript.p1ScoreCount++;
				Transform transform5 = (Transform)UnityEngine.Object.Instantiate(this.collisionPrefab, GameObject.Find("collisionSpawnPoint").transform.position, Quaternion.identity);
				ColliderScript.tieGameCount = 0;
				ColliderScript.updatedCount = true;
			}
			else if (this.circleCount == 3 && !ColliderScript.updatedCount && MenuButtonScript.playerVsPlayer)
			{
				this.StartCoroutine(this.P2Won());
				ScoreScript.p2ScoreCount++;
				Transform transform6 = (Transform)UnityEngine.Object.Instantiate(this.collisionPrefab, GameObject.Find("collisionSpawnPoint").transform.position, Quaternion.identity);
				ColliderScript.tieGameCount = 0;
				ColliderScript.updatedCount = true;
			}
		}
	}

	public override void LateUpdate()
	{
		if (ColliderScript.tieGameCount == 9 && !ColliderScript.playerLost && !ColliderScript.playerWon)
		{
			if (MenuButtonScript.userCrossInput && MenuButtonScript.playerVsComputer)
			{
				int num = UnityEngine.Random.Range(0, 2);
				int num2 = num;
				if (num2 == 0)
				{
					CubeSelectScript.playerCrossTurn = false;
					CubeSelectScript.computerCircleTurn = true;
					this.StartCoroutine(this.Draw());
				}
				else if (num2 == 1)
				{
					CubeSelectScript.playerCrossTurn = true;
					CubeSelectScript.computerCircleTurn = false;
					this.StartCoroutine(this.Draw());
				}
				ScoreScript.pvcDrawCount++;
			}
			else if (MenuButtonScript.userCircleInput && MenuButtonScript.playerVsComputer)
			{
				int num3 = UnityEngine.Random.Range(0, 2);
				int num4 = num3;
				if (num4 == 0)
				{
					CubeSelectScript.playerCircleTurn = false;
					CubeSelectScript.computerCrossTurn = true;
					this.StartCoroutine(this.Draw());
				}
				else if (num4 == 1)
				{
					CubeSelectScript.playerCircleTurn = true;
					CubeSelectScript.computerCrossTurn = false;
					this.StartCoroutine(this.Draw());
				}
				ScoreScript.pvpDrawCount++;
			}
			if (MenuButtonScript.playerVsPlayer)
			{
				this.StartCoroutine(this.Draw());
			}
			ColliderScript.tieGameCount = 0;
		}
	}

	public override IEnumerator PWon()
	{
		return new ColliderScript._0024PWon_00249().GetEnumerator();
	}

	public override IEnumerator PLost()
	{
		return new ColliderScript._0024PLost_002410().GetEnumerator();
	}

	public override IEnumerator Draw()
	{
		return new ColliderScript._0024Draw_002411().GetEnumerator();
	}

	public override IEnumerator P1Won()
	{
		return new ColliderScript._0024P1Won_002412().GetEnumerator();
	}

	public override IEnumerator P2Won()
	{
		return new ColliderScript._0024P2Won_002413().GetEnumerator();
	}

	public override void OnTriggerEnter(Collider hit)
	{
		if (MenuButtonScript.playerVsComputer && hit.gameObject.tag == "cross")
		{
			this.crossCount++;
		}
		else if (MenuButtonScript.playerVsComputer && hit.gameObject.tag == "circle")
		{
			this.circleCount++;
		}
		if (MenuButtonScript.playerVsPlayer && hit.gameObject.tag == "cross")
		{
			this.crossCount++;
			CubeSelectScript.playerOneTurn = false;
			CubeSelectScript.playerTwoTurn = true;
		}
		else if (MenuButtonScript.playerVsPlayer && hit.gameObject.tag == "circle")
		{
			this.circleCount++;
			CubeSelectScript.playerOneTurn = true;
			CubeSelectScript.playerTwoTurn = false;
		}
	}

	public override void Main()
	{
	}

	public Transform collisionPrefab;

	public int crossCount;

	public int circleCount;

	[NonSerialized]
	public static int tieGameCount;

	[NonSerialized]
	public static bool updatedCount;

	[NonSerialized]
	public static bool playerWon;

	[NonSerialized]
	public static bool playerLost;

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024PWon_00249 : GenericGenerator<WaitForSeconds>
	{
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new ColliderScript._0024PWon_00249._0024();
		}
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024PLost_002410 : GenericGenerator<WaitForSeconds>
	{
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new ColliderScript._0024PLost_002410._0024();
		}
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024Draw_002411 : GenericGenerator<WaitForSeconds>
	{
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new ColliderScript._0024Draw_002411._0024();
		}
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024P1Won_002412 : GenericGenerator<WaitForSeconds>
	{
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new ColliderScript._0024P1Won_002412._0024();
		}
	}

	[CompilerGenerated]
	[Serializable]
	internal sealed class _0024P2Won_002413 : GenericGenerator<WaitForSeconds>
	{
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new ColliderScript._0024P2Won_002413._0024();
		}
	}
}
