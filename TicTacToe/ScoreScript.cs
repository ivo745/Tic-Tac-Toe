// dnSpy decompiler from Assembly-UnityScript-firstpass.dll class: ScoreScript
using System;
using UnityEngine;

[Serializable]
public class ScoreScript : MonoBehaviour
{
	public override void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 800f, (float)Screen.height / 480f, 1f));
		if (MenuButtonScript.playerVsPlayer)
		{
			GUI.Box(new Rect((float)10, (float)10, (float)100, (float)25), "P1 Score: " + ScoreScript.p1ScoreCount);
			GUI.Box(new Rect((float)10, (float)35, (float)100, (float)25), "P2 Score: " + ScoreScript.p2ScoreCount);
			GUI.Box(new Rect((float)10, (float)60, (float)100, (float)25), "Draws: " + ScoreScript.pvpDrawCount);
		}
		else
		{
			GUI.Box(new Rect((float)10, (float)10, (float)100, (float)25), "P Score: " + ScoreScript.pScoreCount);
			GUI.Box(new Rect((float)10, (float)35, (float)100, (float)25), "C Score: " + ScoreScript.cScoreCount);
			GUI.Box(new Rect((float)10, (float)60, (float)100, (float)25), "Draws: " + ScoreScript.pvcDrawCount);
		}
	}

	public override void Main()
	{
	}

	[NonSerialized]
	public static int pScoreCount;

	[NonSerialized]
	public static int cScoreCount;

	[NonSerialized]
	public static int p1ScoreCount;

	[NonSerialized]
	public static int p2ScoreCount;

	[NonSerialized]
	public static int pvpDrawCount;

	[NonSerialized]
	public static int pvcDrawCount;
}
