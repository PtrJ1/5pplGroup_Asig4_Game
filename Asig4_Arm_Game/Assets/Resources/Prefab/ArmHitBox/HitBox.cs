using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    bool isHit = false;
    Vector2 hitPosBuffer;
    [SerializeField]
    Transform hitPos;
    public bool isHiting()
    {
        return isHit;
    }
    public Vector2 getHitPos()
    {
        return hitPos.position;//need more detail
    }
    void beHit()
    {
        isHit = true;
    }
    void leaveHit()
    {
        isHit = false;
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlatForm" || collision.gameObject.tag == "Monster")
        { beHit();

            hitPosBuffer = this.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlatForm" || collision.gameObject.tag == "Monster")
            leaveHit();
    }

}
