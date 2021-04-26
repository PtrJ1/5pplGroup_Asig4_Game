using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LandHit : MonoBehaviour, ILandHit
{
    bool _isEnable;
    IRotateArm rotateArm;
    ArmController armController;
    [SerializeField]
    GameObject BoomEFprefab;
    public void disableAbility()
    {
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        _isEnable = true;
        rotateArm = centerController.getRotateArm();
        armController = centerController.getArmController();
    }

    public void Hit()
    {
        StartCoroutine(landHitingProcess());
    }

    public bool isEnabled()
    {
        return _isEnable;
    }

    IEnumerator landHitingProcess()
    {
        float rotateTime = 0;
        while (rotateTime <= 0.05f)//  防止误触
        {
            rotateTime += Time.deltaTime;
            rotateArm.fastRotate();
            yield return new WaitForEndOfFrame();
        }
        do
        {
      
            rotateTime += Time.deltaTime;
            rotateArm.fastRotate();
            yield return new WaitForEndOfFrame();
            
            if (armController.isHiting() == true && rotateTime <= 0.1f) //防止短时间蓄力
            {
                attackFail();
                yield break;
            }
        }
        while (armController.isHiting() == false && rotateTime<=10f) ;

        initialBoom(rotateTime);
        
    }

    void attackFail()
    {

    }

    void initialBoom(float rotateTime)
    {
        GameObject a = Instantiate(BoomEFprefab, armController.getHitPos(),Quaternion.identity);
        a.transform.localScale *= 1 + rotateTime*2;
        CinemachineCollisionImpulseSource cs = this.GetComponent<CinemachineCollisionImpulseSource>();
        cs.m_ImpulseDefinition.m_AmplitudeGain = rotateTime * rotateTime + 0.3f;
        cs.GenerateImpulse();
    }
}
