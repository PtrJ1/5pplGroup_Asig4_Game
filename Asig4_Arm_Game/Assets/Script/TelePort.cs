using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort : MonoBehaviour,ITeleporte
{
     public Vector2 moveDirection;
     public const float maxDashTime = 1.0f;
     public float dashDistance = 10;
     public float dashStoppingSpeed = 0.1f;
     float currentDashTime = maxDashTime;
     float dashSpeed = 6;
     
     CenterController centerController;
     
     
      private void enableAbility(CenterController centerController)
     {
        
        armRig = centerController.getArmController().getRig();
        playerRig = centerController.getRig();
        armController = centerController.getArmController();
     }
 
     // Update is called once per frame
     public void Dash () {
         if (Input.GetButtonDown("Fire2")) //Right mouse button
         {
             currentDashTime = 0;                
         }
         if(currentDashTime < maxDashTime)
         {
             moveDirection = transform.forward * dashDistance;
             currentDashTime += dashStoppingSpeed;
         }
         else
         {
             moveDirection = Vector2.zero;
         }
         centerController.Move(moveDirection * Time.deltaTime * dashSpeed);
     }
 }

}


/*


public class DashAbility : MonoBehaviour {
     
     public DashState dashState;
     public float dashTimer;
     public float maxDash = 20f;
 
     public Vector2 savedVelocity;
     
     void Update () 
     {
         switch (dashState) 
         {
         case DashState.Ready:
             var isDashKeyDown = Input.GetKeyDown (KeyCode.LeftShift);
             if(isDashKeyDown)
             {
                 savedVelocity = rigidbody.velocity;
                 rigidbody.velocity =  new Vector2(rigidbody.velocity.x * 3f, rigidbody.velocity.y);
                 dashState = DashState.Dashing;
             }
             break;
         case DashState.Dashing:
             dashTimer += Time.deltaTime * 3;
             if(dashTimer >= maxDash)
             {
                 dashTimer = maxDash;
                 rigidbody.velocity = savedVelocity;
                 dashState = DashState.Cooldown;
             }
             break;
         case DashState.Cooldown:
             dashTimer -= Time.deltaTime;
             if(dashTimer <= 0)
             {
                 dashTimer = 0;
                 dashState = DashState.Ready;
             }
             break;
         }
     }
 }
 
 public enum DashState 
 {
     Ready,
     Dashing,
     Cooldown
 }

*/
