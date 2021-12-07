using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyFallingObjects : MonoBehaviour
{
    private GameManager mGameManager;


    private void Awake()
    {
        mGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            mGameManager.mCurrentGameStatus = GameStatus.LostGame;
        }
    }
}

