using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeArm : MonoBehaviour, ISlimeArm
{
    HingeJoint2D GrabJoint;
   
    // Start is called before the first frame update
    bool isGrabMode = false;
    bool _isEnabled = false;
    void GrabThing(Rigidbody2D rigidbody2D)
    {
        if (GrabJoint!=null)
        { return; }
        GrabJoint =this.gameObject.AddComponent<HingeJoint2D>();
        GrabJoint.connectedBody = rigidbody2D;

    }
    void releaseThing()
    {
        if (GrabJoint != null)
            GrabJoint.breakForce = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrabMode)
            return;
        if (collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "PlatForm")
        {
            GrabThing(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

  
    public void disableAbility()
    {
        _isEnabled = false;
        deactivate();
    }

    public void enableAbility(CenterController centerController)
    {
     
        _isEnabled = true;
      
    }

    public bool isEnabled()
    {
        return _isEnabled;
    }

    public bool isActivate()
    {
        return isGrabMode;
    }

    public void activate()
    {
        isGrabMode = true;
        this.GetComponentInChildren<SpriteRenderer>().color = Color.green;
    }

    public void deactivate()
    {
        isGrabMode = false;
        releaseThing();
        this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
