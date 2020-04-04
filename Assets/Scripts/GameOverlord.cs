using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverlord : MonoBehaviour
{
	private enum Release
	{
		PC,
		CAB,
		MOBI
	}

	private enum GameMode
	{
		MENU,
		PLAY,
		LOSE
	}

	[SerializeField] Release developmentRelease = Release.PC;

	[SerializeField] GameMode gameMode = GameMode.MENU;

	public string GetCurrentReleaseSetting()
	{
		switch (developmentRelease)
		{
			case Release.PC:
				return "PC";
			case Release.CAB:
				return "Cabinet";
			case Release.MOBI:
				return "Mobile";
			default:
				return "An Error Occured";
		}
	}

	public string GetCurrentGameMode()
	{
		switch (gameMode)
		{
			case GameMode.MENU:
				return "MENU";
			case GameMode.PLAY:
				return "PLAY";
			case GameMode.LOSE:
				return "LOSE";
			default:
				return "An Error Occured";
		}
	}
}
