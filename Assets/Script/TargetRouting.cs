using UnityEngine;

public class TargetRouting : MonoBehaviour
{
    public GameObject nextRoute;
    public CarForce PlayerCar;

    public GameObject Spawn01;
    public GameObject Spawn02;

    public bool isFinish;
    public EndState End;

    public bool wasActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Escort") && wasActivated == false)
        {
            wasActivated = true;

            if (isFinish == true)
            {
                End.Ended = true;
            } else
            {

                if (Random.value > 5)
                {
                    Spawn01.SetActive(true);
                }
                else
                {
                    Spawn02.SetActive(true);
                }

                PlayerCar = other.gameObject.GetComponentInParent<CarForce>();
                PlayerCar.NextRoute = nextRoute.transform;
            }


        }
    }
}
