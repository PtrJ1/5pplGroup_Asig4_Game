using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveMent : MonoBehaviour, IBasicMoveMent
{

    bool _isEnable = true;
    bool _isActivate = false;
    Rigidbody2D rig;
    float moveSpeed = 5f;

    public void activate()
    {
       _isActivate = true;
    }

    public bool isEnabled()
    {
        return _isEnable;
    }
   

    public void moveLeft()
    {
        rig.velocity = new Vector2( -moveSpeed, rig.velocity.y);
    }

    public void moveRight()
    {
        rig.velocity = new Vector2(moveSpeed, rig.velocity.y);
    }

 

    public void disableAbility()
    {
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        rig = centerController.getRig();
        _isEnable = true;
    }



   
   public  bool isActivate()
    {
        return _isActivate;
    }

    public void deactivate()
    {
        _isActivate = false;
    }
}
