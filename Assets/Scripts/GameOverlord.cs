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
		START,
		MENU,
		PLAY,
		GAMEOVER
	}

	[SerializeField] Release developmentRelease = Release.PC;

	[SerializeField] GameMode gameMode = GameMode.START;

	private int numPlayers = 0;

	UIController uIController;

	private void Start()
	{
		uIController = GetComponent<UIController>();

		uIController.TriggerTransitioner(false);
	}

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
			case GameMode.START:
				return "START";
			case GameMode.MENU:
				return "MENU";
			case GameMode.PLAY:
				return "PLAY";
			case GameMode.GAMEOVER:
				return "GAMEOVER";
			default:
				return "An Error Occured";
		}
	}

	public void AddRemovePlayer(int value)
	{
		if(value > 0)
		{
			if(numPlayers < 4)
				numPlayers++;
		}
		else
		{
			if(numPlayers > 0)
				numPlayers--;
		}
	}

	public int GetNumPlayers()
	{
		return numPlayers;
	}

	public void StartGame()
	{
		gameMode = GameMode.PLAY;

		GetComponent<UIController>().EnablePlayerSelectMenu(false);

		GetComponent<UIController>().EnablePlayCanvas(true);

		GetComponent<PlayerControls>().SetActivePlayers();

		// also some music

	}

	public void GameOver()
	{
		gameMode = GameMode.GAMEOVER;

		GetComponent<UIController>().EnablePlayCanvas(false);

		GetComponent<UIController>().EnableGameOverScreen(true);
	}

	public void LoadPlayerSelect()
	{
		uIController.EnableTitleScreen(false);

		gameMode = GameMode.MENU;

		uIController.EnablePlayerSelectMenu(true);
	}
}
