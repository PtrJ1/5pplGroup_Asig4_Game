using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IRotateArm:IAbility,iActivateAbility
{
    void rotateLeft();
    void rotateRight();
    void stopRotate();
    void fastRotate();
    //void breakJoint();
    //void reconNectJoint();

}
