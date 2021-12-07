using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int mSpeed;
    public int mJumpForce;
    public LayerMask mGroundLayer;
    public Transform mGroundCheck;
    public SoundManager mSoundManager;
    public AudioClip mJumpSound;
    public bool mIsColorSwitched;
    public bool mCanJump;
    public bool mCanSwitch = true;
    public int mMaximumSwitches;
    public TimeOfDay mStartingTime;
   
    private Rigidbody2D mRigidB;
    private bool mCanMove = true;
    private SpriteRenderer mSpriteRenderer;
    private int mRemainingSwitches;



    void Start()
    {
        mRigidB = GetComponent<Rigidbody2D>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        mRemainingSwitches = mMaximumSwitches;


        if(mStartingTime == TimeOfDay.Day)
        {
            mSpriteRenderer.color = Color.yellow; 
        }
        else
        {
            mSpriteRenderer.color = Color.black;
        }

    }

    void Update()
    {
        //Player Switch
        if(Input.GetKeyDown(KeyCode.S) && mCanSwitch)
        {
            mSoundManager.MakeSwitchSound();
            if (mSpriteRenderer.color == Color.black)
            {
                mSpriteRenderer.color = Color.yellow;
                //mIsColorSwitched = false;
            }
            else if (mSpriteRenderer.color == Color.yellow)
            {
                mSpriteRenderer.color = Color.black;
                //mIsColorSwitched = true;
            }

            //if(mIsDay)
            //{
            //    mSpriteRenderer.color = Color.yellow;
            //    mIsDay = false;
            //}
            //else
            //{
            //    mSpriteRenderer.color = Color.black;
            //    mIsDay = true;
            //}

            mRemainingSwitches--;
            
            //mRemainingSwitches = Mathf.Clamp(mRemainingSwitches, 0, mMaximumSwitches);
        }

        // Player Movement
        if (mCanMove)
        {
            Move();
        }


        // Player Jump
        if (Input.GetButtonDown("Jump") && mCanJump)
        {
            Jump();
        }

        bool grounded = Physics2D.Linecast(
        new Vector2(transform.position.x, transform.position.y),
        mGroundCheck.position,
        mGroundLayer);

        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y),
            mGroundCheck.position,
            Color.red);

        if (grounded)
        {
            mCanJump = true;
        }
        else
        {
            mCanJump = false;
        }

    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * mSpeed, 0,
        Input.GetAxis("Vertical") * mSpeed);

        mRigidB.velocity = new Vector3(movement.x, mRigidB.velocity.y, 0f);
    }

    void Jump()
    {
        mCanJump = false;
        mRigidB.AddForce(Vector2.up * mJumpForce);
        Debug.Log("JUMP");
        mSoundManager.MakeJumpSound();

    }

    private IEnumerator Knockback()
    {
        mCanMove = false;
        mRigidB.AddForce(transform.forward * -800);
        mRigidB.AddForce(transform.up * 200);
        GetComponent<PlayerScore>().mScore -= 100;
        yield return new WaitForSeconds(0.6f);
        mCanMove = true;
    }


    public int GetRemainingSwitches()
    {
        return mRemainingSwitches;
    }
}
