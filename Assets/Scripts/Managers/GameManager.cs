using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
	StartGame,
	PauseGame,
	EndLevel,
	EndGame,
	LostGame
}

public class GameManager : MonoBehaviour
{

	//public RaceTimer mRaceTimer;
	public MenuManager mMenuManager;
	public GameStatus mCurrentGameStatus;
	public PlayerController mPlayer;
	public SoundManager mSoundManager;

	//====================================================================================================


	void Awake()
	{

		mCurrentGameStatus = GameStatus.StartGame;

	}

	private void Start()
    {

		//mRaceTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<RaceTimer>();
		mMenuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
		

		//if(mRaceTimer != null)
  //      {
		//	mRaceTimer.ResetTimer();
		//}


		Time.timeScale = 1;

	}

    void Update()
	{
		//if(mRaceTimer.mTimeRemaining <= 0)
  //      {
		//	mCurrentGameStatus = GameStatus.LostGame;
		//}

		if(mPlayer.GetRemainingSwitches() < 0 && mCurrentGameStatus == GameStatus.StartGame)
        {
			mCurrentGameStatus = GameStatus.LostGame;
			mPlayer.mCanSwitch = false;
		}

		if (mCurrentGameStatus == GameStatus.StartGame)
		{
			Time.timeScale = 1;
			mPlayer.mCanSwitch = true;

			//mRaceTimer.StartCoroutine("CalculateTime");
			Debug.Log("Status START Game");
		}

		else if (mCurrentGameStatus == GameStatus.EndLevel)
		{
			Time.timeScale = 0;
			//mRaceTimer.StopCoroutine("CalculateTime");
			//mRaceTimer.ResetTimer();
			Debug.Log("Status END LEVEL");
			//mSoundManager.MakeEndLevelSound();

			mMenuManager.SwitchMenu(MenuType.LevelCompleteMenu);
		}
		else if (mCurrentGameStatus == GameStatus.PauseGame)
		{
			Time.timeScale = 0;
			mPlayer.mCanSwitch = false;
			Debug.Log("Status PAUSE Game");

		}
		else if (mCurrentGameStatus == GameStatus.EndGame)
		{
			Time.timeScale = 0;
			//mSoundManager.MakeEndLevelSound();
			//  Won the game back to main menu 

		}
		else if(mCurrentGameStatus == GameStatus.LostGame)
        {
			Time.timeScale = 0;
			//mRaceTimer.StopCoroutine("CalculateTime");
			//mRaceTimer.ResetTimer();
			Debug.Log("LOST GAME");

			//mSoundManager.MakeFailSound();
			mMenuManager.SwitchMenu(MenuType.LostGame);
		}







	}

	
}
