using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandHit : MonoBehaviour, ILandHit
{
    bool _isEnable;

    public void disableAbility()
    {
        throw new System.NotImplementedException();
    }

    public void enableAbility(CenterController centerController)
    {
        _isEnable = true;
    }

    public void Hit()
    {
        throw new System.NotImplementedException();
    }

    public bool isEnabled()
    {
        return _isEnable;
    }
}
