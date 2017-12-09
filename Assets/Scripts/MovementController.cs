using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MovementController : MonoBehaviour {


    private bool shouldMoveUp;
    private bool shouldMoveDown;
    private bool shouldMoveLeft;
    private bool shouldMoveRight;

    private Vector2 velocity = new Vector2(0, -1);

    private TriggerDetect _triggerDetectNorth;
    private TriggerDetect _triggerDetectEast;
    private TriggerDetect _triggerDetectWest;
    private TriggerDetect _triggerDetectSouth;

    private Rigidbody2D _rb2d;
    private Animator _animator;

    // Use this for initialization
    void Start () {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _triggerDetectNorth = GameObject.FindGameObjectWithTag("NorthTrigger").GetComponent<TriggerDetect>();
        _triggerDetectEast = GameObject.FindGameObjectWithTag("EastTrigger").GetComponent<TriggerDetect>();
        _triggerDetectSouth = GameObject.FindGameObjectWithTag("SouthTrigger").GetComponent<TriggerDetect>();
        _triggerDetectWest = GameObject.FindGameObjectWithTag("WestTrigger").GetComponent<TriggerDetect>();
    }

    // Update is called once per frame
    void Update () {
        #region input
        {
            if (isPressingUp() && (velocity.y != -1) && (_triggerDetectNorth.isTriggered == false))
            {
                _animator.SetBool("walkUp", true);
                _animator.SetBool("walkDown", false);
                _animator.SetBool("walkSideways", false);
                shouldMoveUp = true;
            }
            else if (isPressingDown() && (velocity.y != 1) && (_triggerDetectSouth.isTriggered == false))
            {
                _animator.SetBool("walkUp", false);
                _animator.SetBool("walkDown", true);
                _animator.SetBool("walkSideways", false);
                shouldMoveDown = true;
            }
            else if (isPressingLeft() && (velocity.x != 1) && (_triggerDetectWest.isTriggered == false))
            {
                _animator.SetBool("walkUp", false);
                _animator.SetBool("walkDown", false);
                _animator.SetBool("walkSideways", true);
                shouldMoveLeft = true;
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (isPressingRight() && (velocity.x != -1) && (_triggerDetectEast.isTriggered == false))
            {
                _animator.SetBool("walkUp", false);
                _animator.SetBool("walkDown", false);
                _animator.SetBool("walkSideways", true);
                shouldMoveRight = true;
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }
        #endregion  

    }

    private void FixedUpdate()
    {
        #region movement
        {
            if (shouldMoveUp)
            {
                velocity.x = 0;
                velocity.y = 1;
                shouldMoveUp = false;
            } else if (shouldMoveDown)
            {
                velocity.x = 0;
                velocity.y = -1;
                shouldMoveDown = false;
            } else if (shouldMoveRight)
            {
                velocity.x = 1;
                velocity.y = 0;
                shouldMoveRight = false;
            } else if (shouldMoveLeft)
            {
                velocity.x = -1;
                velocity.y = 0;
                shouldMoveLeft = false;
            }

        }
        #endregion

        _rb2d.velocity = velocity * 2;
    }

    public bool isPressingRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    public bool isPressingLeft()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    public bool isPressingUp()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    public bool isPressingDown()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }
}
