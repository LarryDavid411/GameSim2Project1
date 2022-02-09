using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAttributes : MonoBehaviour
{
    public bool introBrick;
    public int health;

    public bool brickBeingAttacked;
    public float attackTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (brickBeingAttacked)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > 1.0f)
            {
                health -= 1;
                attackTimer = 0;
            }
            Debug.Log(health);
            switch (health)
            {
                case 3:
                {
                    
                }
                    break;
                case 2:
                {
                    
                }
                    break;
                case 1:
                {
                    
                }
                    break;
                case 0:
                {
                    gameObject.SetActive(false);
                }
                    break;
            }
            
            
            
            
            
            
        }
        
    }
}
