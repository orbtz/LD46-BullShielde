using UnityEngine;

public class ProjectileDetector : MonoBehaviour
{
    public ProtectionCar PlayerCar;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("EnemyProjectile"))
        {

            PlayerCar.isProjectileClose = true;
            PlayerCar.ProjectileObject = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag.Equals("EnemyProjectile"))
        {

            PlayerCar.isProjectileClose = false;
            PlayerCar.ProjectileObject = null;

        }
    }
}
