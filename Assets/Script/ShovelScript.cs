using UnityEngine;

public class ShovelScript : MonoBehaviour
{
    public AudioSource Hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EscortDetector script = other.GetComponent<EscortDetector>();
            Rigidbody otherRB = other.GetComponent<Rigidbody>();
            GameObject Parent = other.transform.parent.gameObject;
            //CarForce script2 = other.GetComponent<EscortDetector>().gameObject.GetComponent<CarForce>();

            script.enabled = false;
            //script2.enabled = false;

            otherRB.constraints = RigidbodyConstraints.None;
            otherRB.AddExplosionForce(3000 * otherRB.mass, this.transform.position + (Vector3.down * 2), 50);

            otherRB.AddTorque(Vector3.forward * 5000, ForceMode.Impulse);

            Hit.Play();

            Destroy(Parent, 1.5f);
        }
    }
}
