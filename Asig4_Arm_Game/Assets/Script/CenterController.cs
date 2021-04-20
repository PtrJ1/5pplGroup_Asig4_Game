using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterController : MonoBehaviour
{
    IBasicMoveMent basicMoveMent;
    IRotateArm rotateArm;
    ILandHit landHit;
    IGrapple grapple;
    ISlimeArm slimeArm;
    ITeleporte teleporte;
    IChargeArm chargeArm;
    Rigidbody2D rig;
    [SerializeField]
    ArmController armController;
    bool isStun; // if player is stun , all input will be ignore;
    // Start is called before the first frame update

   public  Rigidbody2D getRig()
    {
        return rig;
    }
   public  ArmController getArmController()
    {
        return armController;
    }
    public IRotateArm getRotateArm()
    {
        return rotateArm;
    }

    void Start()
    {
        getComponents();
        getAbilities();
    }

    void getAbilities()
    {   try
        {   basicMoveMent = this.GetComponentInChildren<IBasicMoveMent>();
            basicMoveMent.enableAbility(this);
            basicMoveMent.activate();
        }
        catch
        {
           
        }
        try
        {
            rotateArm = this.GetComponentInChildren<IRotateArm>();
            rotateArm.enableAbility(this);
            rotateArm.deactivate();
        }
        catch
        {

        }

        try
        {
            grapple = armController.GetComponentInChildren<IGrapple>();
            grapple.enableAbility(this);
        }
        catch
        {

        }
        try
        {
            landHit = this.GetComponentInChildren<ILandHit>();
        }
        catch
        {

        }
        try
        {
            slimeArm  = armController.GetComponent<ISlimeArm>();
            slimeArm.enableAbility(this);
            Debug.Log(slimeArm);
        }
        catch
        {
            Debug.LogError("No SlimeArm");
        }
        try
        {
            teleporte = this.GetComponentInChildren<ITeleporte>();
        }
        catch
        {

        }

        try
        {
            chargeArm = this.GetComponentInChildren<IChargeArm>();
        }
        catch
        {

        }
    


    }
    void getComponents()
    {
        rig = this.GetComponent<Rigidbody2D>();
       
    }
    // Update is called once per frame
    void Update()
    {
        playerInput();

    }

    void playerInput()
    {    if (isStun)
            return;
        if (Input.GetKey(KeyCode.A))
            moveLeft();
        if (Input.GetKey(KeyCode.D))
            moveRight();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && rotateArm.isEnabled())
            rotateArm.stopRotate();
        if (Input.GetKeyDown(KeyCode.Space))
            swichMoveMent();
        if (Input.GetKeyDown(KeyCode.W)&&slimeArm.isEnabled())
            slimeArm.activate();
        if (!Input.GetKey(KeyCode.W)&&slimeArm.isEnabled())
            slimeArm.deactivate();
        if (Input.GetKey(KeyCode.J)&&grapple.isEnabled()&&rotateArm.isActivate())
            shootHook();
   

    }

    public void setStun(bool value)
    {
        isStun = value;
    }
   

    void moveLeft() // Move to left , the movement way depends on which ability is enabled
    {
     
        if (rotateArm.isEnabled()&&rotateArm.isActivate())
        {
            rotateArm.rotateLeft();
        }
        else
        {
            basicMoveMent.moveLeft();
        }
    }
    void moveRight() // Move to right , the movement way depends on which ability is enabled
    {
        if (rotateArm.isEnabled() && rotateArm.isActivate())
        {
            rotateArm.rotateRight();
        }
        else
        {
            basicMoveMent.moveRight();
        }
    }
    public void swichMoveMent() //Switch the movement way between rotating arm and walking
    {
   
        if(rotateArm.isEnabled())
        {
            if(basicMoveMent.isActivate())
            {
                basicMoveMent.deactivate();
                rotateArm.activate();
            }
            else
            {
                basicMoveMent.activate();
                rotateArm.deactivate();
            }

        }

    }

    public void shootHook()
    {

        grapple.shootHook();
    }

   
}
