using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMController : MonoBehaviour
{

    public GameObject player;

    public enum State
    {
        Idle,
        Walking,
        ActivelyMoving
    }

    public State state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
    }


    public void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3();

        switch (state)
        {
            case State.Idle:
            {
                if (moveX != 0 || moveY != 0)
                {
                    state = State.Walking;
                }    
            }
                break;

            case State.Walking:
            {
                if (moveX == 0 || moveY == 0)
                {
                    state = State.Idle;
                }

                moveDir.x = moveX;
                moveDir.y = moveY;
            }
                break;
        }
        
        
        
        CharacterController c = player.GetComponent<CharacterController>();
        c.Move(moveDir * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
