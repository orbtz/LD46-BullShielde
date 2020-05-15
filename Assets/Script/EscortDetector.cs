using UnityEngine;

public class EscortDetector : MonoBehaviour
{
    public GameObject EnemyGameObject;
    public EscortLife TargetLife;

    public CameraShake Shake;

    public int Damage;

    public AudioSource Hit;
    public AudioSource Crunch;

    public HingeJoint FL;
    public HingeJoint FR;
    public HingeJoint RL;
    public HingeJoint RR;

    private void Start()
    {
        Crunch = GameObject.Find("Crunch").GetComponent<AudioSource>();
        Hit = GameObject.Find("Hit").GetComponent<AudioSource>();

        //Crunch.Play();
        //Hit.Play();

        if (TargetLife == null)
        {
            TargetLife = GameObject.Find("CAR").GetComponent<EscortLife>();

        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Escort"))
        {
            TargetLife.LoseLife(Damage);

            //Shake.enabled = true;

            Destroy(EnemyGameObject);
        }

        if (other.gameObject.tag.Equals("PlayerProjectile"))
        {
            GameObject Parent = this.transform.parent.gameObject;

            Crunch.Play();

            //Shake.enabled = true;

            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            this.gameObject.GetComponent<Rigidbody>().AddForce( (Vector3.up) * 10 , ForceMode.Impulse);


            // Vai quebrar as hinges
            Destroy(FL);
            Destroy(FR);
            Destroy(RR);
            Destroy(RL);

            Destroy(Parent, 2);
            Destroy(other.gameObject, 2);
            Destroy(this.gameObject, 2);
        }
    }
}
