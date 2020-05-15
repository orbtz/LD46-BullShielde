using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public ProtectionCar ProtectionCar;

    public bool hasHitGround;
    public bool isBaseOnGround;

    public bool isPlayingCountdown;

    IEnumerator CountdownFlip()
    {
        yield return new WaitForSeconds(1.5f);

        if (hasHitGround == true && isBaseOnGround == false)
        {
            ProtectionCar.willRestartPosition = true;
        }

        isPlayingCountdown = false;

    }

    private void Update()
    {
        if (hasHitGround == true && isBaseOnGround == false)
        {
            isPlayingCountdown = true;
            StartCoroutine("CountdownFlip");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Plano") {isBaseOnGround = true;}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Plano") {isBaseOnGround = false;}
    }

    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            hasHitGround = true;
            ProtectionCar.isOnAir = false;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            hasHitGround = false;
            ProtectionCar.isOnAir = true;
        }
    }
}
