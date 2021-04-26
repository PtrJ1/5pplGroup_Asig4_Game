using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour, IRotateArm
{
    ArmController armController;
    HingeJoint2D joint2D;
    Rigidbody2D rig;
    bool _isEnable = false;
    bool _isActivate = false;
    bool isOnRight = false;
    [SerializeField]
    float rotateSpeed = 50;
    [SerializeField]
    float maxForce = 20;
    public bool isEnabled()
    {
        return _isEnable;
    }

   
    public void disableAbility()
    {
        armController.hideArm();
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        armController = centerController.getArmController();
        joint2D = armController.getJoint();
        rig = armController.getRig();
        armController.showArm();
        _isEnable = true;
    }



    public void rotateLeft()
    {
        rotate(-rotateSpeed);
        isOnRight = false;
    }

    public void fastRotate()
    {
        if(isOnRight)
        rotate(rotateSpeed * 3.5f);
        else
            rotate(-rotateSpeed * 3.5f);
    }
    void rotate(float Speed)
    {
        joint2D.useMotor = true;
        JointMotor2D motor = joint2D.motor;
        motor.maxMotorTorque = maxForce;
        motor.motorSpeed = Speed;
        joint2D.motor = motor;
    }
    public void rotateRight()
    {
        rotate(rotateSpeed);
        isOnRight = true;
    }

    public void stopRotate()
    {
        if(joint2D!=null)
        joint2D.useMotor = false;
    }

    public bool isActivate()
    {
        return _isActivate;
    }

    public void activate()
    {
        _isActivate = true;
        armController.showArm();
    }

    public void deactivate()
    {
        _isActivate = false;
        armController.hideArm();
    }

    //public void breakJoint()
    //{
    //    joint2D.breakForce = 0;
    //    rig.freezeRotation = true;
    //}

    //public void reconNectJoint()
    //{
    //    throw new System.NotImplementedException();
    //}
}
