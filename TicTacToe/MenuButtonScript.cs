// dnSpy decompiler from Assembly-UnityScript-firstpass.dll class: MenuButtonScript
using System;
using UnityEngine;

[Serializable]
public class MenuButtonScript : MonoBehaviour
{
	public override void OnMouseUp()
	{
		if (this.isStartButton)
		{
			CubeSelectScript.startGameCount = 0;
			UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		}
		if (this.isExitButton)
		{
			Application.Quit();
		}
		if (this.isOptionButton)
		{
			this.showOptionsDropDown = true;
		}
		else
		{
			this.showOptionsDropDown = false;
			this.showGraphicsDropDown = false;
		}
	}

	public override void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.width / 800f, (float)Screen.height / 480f, 1f));
		if (this.showOptionsDropDown)
		{
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 150), (float)(Screen.height / 2 + 40), (float)250, (float)50), "Play Mode"))
			{
				this.showGraphicsDropDown = false;
				this.showScoreResetDropDown = false;
				this.showUserInputDropDown = false;
				this.showPlayModeDropDown = true;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 150), (float)(Screen.height / 2 + 90), (float)250, (float)50), "User Input"))
			{
				if (MenuButtonScript.playerVsComputer)
				{
					this.showPlayModeDropDown = false;
					this.showScoreResetDropDown = false;
					this.showGraphicsDropDown = false;
					this.showUserInputDropDown = true;
				}
				else
				{
					this.showUserInputDropDown = false;
				}
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 150), (float)(Screen.height / 2 + 140), (float)250, (float)50), "Reset Scores"))
			{
				this.showPlayModeDropDown = false;
				this.showGraphicsDropDown = false;
				this.showUserInputDropDown = false;
				this.showScoreResetDropDown = true;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 150), (float)(Screen.height / 2 + 190), (float)250, (float)50), "Graphics"))
			{
				this.showPlayModeDropDown = false;
				this.showScoreResetDropDown = false;
				this.showUserInputDropDown = false;
				this.showGraphicsDropDown = true;
			}
			if (UnityEngine.Input.GetKeyDown("escape"))
			{
				this.showOptionsDropDown = false;
			}
		}
		if (this.showGraphicsDropDown && !this.showUserInputDropDown && !this.showPlayModeDropDown && !this.showScoreResetDropDown)
		{
			QualityLevel qualityLevel = QualityLevel.Fastest;
			QualityLevel qualityLevel2 = QualityLevel.Simple;
			QualityLevel qualityLevel3 = QualityLevel.Good;
			QualityLevel qualityLevel4 = QualityLevel.Fantastic;
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 40), (float)250, (float)50), "Fastest"))
			{
				QualitySettings.SetQualityLevel((int)qualityLevel);
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 90), (float)250, (float)50), "Simple"))
			{
				QualitySettings.SetQualityLevel((int)qualityLevel2);
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 140), (float)250, (float)50), "Good"))
			{
				QualitySettings.SetQualityLevel((int)qualityLevel3);
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 190), (float)250, (float)50), "Fantastic"))
			{
				QualitySettings.SetQualityLevel((int)qualityLevel4);
			}
			if (UnityEngine.Input.GetKeyDown("escape"))
			{
				this.showGraphicsDropDown = false;
			}
		}
		if (this.showUserInputDropDown && !this.showGraphicsDropDown && !this.showPlayModeDropDown && !this.showScoreResetDropDown)
		{
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 40), (float)250, (float)50), "Cross"))
			{
				MenuButtonScript.userCrossInput = true;
				MenuButtonScript.userCircleInput = false;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 90), (float)250, (float)50), "Circle"))
			{
				MenuButtonScript.userCircleInput = true;
				MenuButtonScript.userCrossInput = false;
			}
			if (UnityEngine.Input.GetKeyDown("escape"))
			{
				this.showUserInputDropDown = false;
			}
		}
		if (this.showPlayModeDropDown && !this.showGraphicsDropDown && !this.showScoreResetDropDown && !this.showUserInputDropDown)
		{
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 40), (float)250, (float)50), "Player VS Computer"))
			{
				MenuButtonScript.playerVsComputer = true;
				MenuButtonScript.playerVsPlayer = false;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 90), (float)250, (float)50), "Player VS Player"))
			{
				MenuButtonScript.userCrossInput = true;
				MenuButtonScript.playerVsComputer = false;
				MenuButtonScript.playerVsPlayer = true;
			}
			if (UnityEngine.Input.GetKeyDown("escape"))
			{
				this.showPlayModeDropDown = false;
			}
		}
		if (this.showScoreResetDropDown && !this.showGraphicsDropDown && !this.showPlayModeDropDown && !this.showUserInputDropDown)
		{
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 40), (float)250, (float)50), "Player VS Computer"))
			{
				ScoreScript.pScoreCount = 0;
				ScoreScript.cScoreCount = 0;
				ScoreScript.pvcDrawCount = 0;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + -100), (float)(Screen.height / 2 + 90), (float)250, (float)50), "Player VS Player"))
			{
				ScoreScript.p1ScoreCount = 0;
				ScoreScript.p2ScoreCount = 0;
				ScoreScript.pvpDrawCount = 0;
			}
			if (UnityEngine.Input.GetKeyDown("escape"))
			{
				this.showScoreResetDropDown = false;
			}
		}
	}

	public override void Main()
	{
	}

	public bool isStartButton;

	public bool isExitButton;

	public bool isOptionButton;

	public bool showOptionsDropDown;

	public bool showGraphicsDropDown;

	public bool showUserInputDropDown;

	public bool showPlayModeDropDown;

	public bool showScoreResetDropDown;

	[NonSerialized]
	public static bool playerVsComputer = true;

	[NonSerialized]
	public static bool playerVsPlayer;

	[NonSerialized]
	public static bool userCircleInput;

	[NonSerialized]
	public static bool userCrossInput = true;
}
