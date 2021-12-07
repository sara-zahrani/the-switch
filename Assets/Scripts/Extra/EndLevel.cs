using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private GameManager mGameManager;
    public TimeOfDay mEndGoalType;

    private void Awake()
    {
        mGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(mEndGoalType == TimeOfDay.Day)
            {
                if(collision.gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
                {
                    mGameManager.mCurrentGameStatus = GameStatus.EndLevel;

                }
                else
                {
                    mGameManager.mCurrentGameStatus = GameStatus.LostGame;

                }

            }
            else if (mEndGoalType == TimeOfDay.Night)
            {
                if (collision.gameObject.GetComponent<SpriteRenderer>().color == Color.black)
                {
                    mGameManager.mCurrentGameStatus = GameStatus.EndLevel;

                }
                else
                {
                    mGameManager.mCurrentGameStatus = GameStatus.LostGame;

                }
            }

        }
    }
}
