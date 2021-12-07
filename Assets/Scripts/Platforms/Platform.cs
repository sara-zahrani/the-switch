using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformType
{
    Day,
    Night,
    Switcher
};

public enum TimeOfDay
{
    Day,
    Night
};

public class Platform : MonoBehaviour
{

    public PlatformType mPlatformType;
    public float mPlatformFallingSpeed;
    public SoundManager mSoundManager;
    public GameManager mGameManager;
    public Transform mPlatformParent;
    private List<Transform> mPlatforms = new List<Transform>();


    private SpriteRenderer mSpriteRenderer;
    private Rigidbody2D mRigB;
    private bool mSwitched = false;
    private bool mFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mRigB = GetComponent<Rigidbody2D>();
        if (mPlatformType == PlatformType.Day)
        {
            mSpriteRenderer.color = Color.yellow;
        }
        if (mPlatformType == PlatformType.Night)
        {
            mSpriteRenderer.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (mPlatformType == PlatformType.Day || mPlatformType == PlatformType.Night)
            {
                Fall(collision.gameObject);
            }
            else if (mPlatformType == PlatformType.Switcher && !mSwitched)
            {
                SwitchPlayerTime(collision.gameObject);

                //so it get's switched only once
                mSwitched = true;
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (mPlatformType == PlatformType.Day || mPlatformType == PlatformType.Night)
            {
                Fall(collision.gameObject);
            }
            //else if (mPlatformType == PlatformType.Switcher)
            //{
            //    SwitchPlayerTime(collision.gameObject);
            //}
        }

    }

    public void Fall(GameObject obj)
    {
        if (obj.GetComponent<SpriteRenderer>().color != mSpriteRenderer.color
            && obj.GetComponent<PlayerController>().mCanJump)
        {
            mRigB.bodyType = RigidbodyType2D.Dynamic;
            //mSoundManager.MakePlatformFalltSound();

        }
        else
        {
            mRigB.bodyType = RigidbodyType2D.Static;
        }
    }


    public void SwitchPlayerTime(GameObject obj)
    {
        SpriteRenderer spriteRend = obj.GetComponent<SpriteRenderer>();

        //if(obj.GetComponent<PlayerController>().mCanJump)
        //{
            if (spriteRend.color == Color.black)
            {
                spriteRend.color = Color.yellow;
            }
            else
            {
                spriteRend.color = Color.black;
            }

            mSpriteRenderer.color = Color.gray;
            mSoundManager.MakeSwitchPlatformSound();
        //}


    }


    //public void FlipColors(GameObject obj)
    //{
    //    SpriteRenderer spriteRend = obj.GetComponent<SpriteRenderer>();

    //    //if (obj.GetComponent<PlayerController>().mCanJump)
    //    //{
    //        if(mPlatformParent != null)
    //        {
    //            foreach (Transform child in mPlatformParent)
    //            {
    //                if(child.GetComponent<SpriteRenderer>().color == Color.black)
    //                {
    //                    child.GetComponent<SpriteRenderer>().color = Color.yellow;
    //                }
    //                else if (child.GetComponent<SpriteRenderer>().color == Color.yellow)
    //                {
    //                    child.GetComponent<SpriteRenderer>().color = Color.black;
    //                }
    //            }

    //            mSpriteRenderer.color = Color.gray;
               
    //        }
    //    //}
    //}

}
