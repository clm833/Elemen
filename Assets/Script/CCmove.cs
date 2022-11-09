using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCmove : MonoBehaviour
{
   public CharacterController CC;
    public float speed;
    public float gravity;
    public float jumpspeed;
    private float verticalForce;
    public int GoThrough;
    public int StandarLayer;
    public bool IsSliding;
    public float slideTime;     
 //   public Collider hitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetButtonDown("Fire1"))
            Debug.Log("Bang");

        if (verticalForce > 0)
            gameObject.layer = GoThrough;
        else if (!IsSliding)
            gameObject.layer = StandarLayer;

        verticalForce -= gravity*Time.deltaTime;
        if (CC.isGrounded)
            verticalForce = 0;
        //Fallcheck();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.layer = GoThrough;
                IsSliding = true;
                Invoke("goThrough", slideTime);
            }
            else
                verticalForce += jumpspeed;
        }
        float HorizontalForce = speed  * Input.GetAxis("Horizontal");
     //   float VerticalForce = speed * Input.GetAxis("Vertical");

        Vector3 move = transform.forward *HorizontalForce;
       // Vector3 move1 = transform.forward *VerticalForce;
        move.y = verticalForce;
       // move1.x = verticalForce;
        CC.Move(move * Time.deltaTime);
      

    }

  /* public void Fallcheck()
    {
        if (verticalForce < -0.9 && !CC.isGrounded)
            hitbox.enable = true;
        else
            hitbox.enable = false;
    }*/

    public void goThrough()
    {
        IsSliding = false;
    }


}
