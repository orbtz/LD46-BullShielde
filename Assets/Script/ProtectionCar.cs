using System.Collections;
using UnityEngine;

public class ProtectionCar : MonoBehaviour
{

    public Rigidbody CarRigidBody;
    public GameObject CarBody;

    public BoxCollider GroundCheck;

    public bool isOnAir;

    public bool willRestartPosition;

    public SphereCollider ProjectileTrigger;
    public GameObject ProjectileObject;
    public ProjectileData ProjectileDataInfo;
    public bool isProjectileClose;
    public bool isOnSlowmotion;

    public MasterTimeData MasterTimeData;
    public CameraFollow CameraSmooth;

    public CameraShake Shake;

    public AudioSource JumpAudio;
    public AudioSource Crunch;

    IEnumerator RestartCollider()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        CarBody.GetComponent<MeshCollider>().enabled = true;
    }

    IEnumerator RestartGravity()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        ProjectileObject.GetComponent<Rigidbody>().useGravity = true;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CarBody.transform.eulerAngles = new Vector3(
                0,
                CarBody.transform.eulerAngles.y,
                0
            );
        }

        if (willRestartPosition == true)
        {
            willRestartPosition = false;

            CarBody.transform.eulerAngles = new Vector3(
                0,
                CarBody.transform.eulerAngles.y,
                0
            );

        }
    }

    private void FixedUpdate()
    {

        if (isOnAir == true)
        {
            ProjectileTrigger.enabled = true;

            if (isProjectileClose == true)
            {
                MasterTimeData.willSlowTime = true;
                ProjectileDataInfo = ProjectileObject.GetComponent<ProjectileData>();

                CameraSmooth.ObjectFollow = ProjectileDataInfo.Origin;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //StartCoroutine(CameraSmooth.CameraReset());

                    CarBody.GetComponent<MeshCollider>().enabled = false;

                    Vector3 velocity = Vector3.zero;
                    CarRigidBody.transform.position = ProjectileObject.transform.position;
                    CarRigidBody.angularVelocity = velocity;
                    CarRigidBody.velocity = velocity;

                    ProjectileObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    //ProjectileObject.GetComponent<Rigidbody>().useGravity = false;
                    ProjectileObject.GetComponent<Rigidbody>().AddForce( (ProjectileDataInfo.Origin.transform.position - ProjectileObject.transform.position) * 5, ForceMode.Impulse);

                    Shake.enabled = true;

                    Crunch.Play();

                    ProjectileObject.tag = "PlayerProjectile";

                    StartCoroutine(RestartGravity());
                    StartCoroutine(RestartCollider());

                    ProjectileObject = null;
                    isProjectileClose = false;

                    //CarBody.GetComponent<MeshCollider>().enabled = true;

                }
            }
        } else
        {
            ProjectileTrigger.enabled = false;
        }


        if (isOnAir == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                CarRigidBody.AddRelativeForce(Vector3.forward * 1f, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                CarRigidBody.AddRelativeForce(-Vector3.forward * 1f, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                CarRigidBody.AddRelativeTorque(Vector3.up * 0.8f, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                CarRigidBody.AddRelativeTorque(-Vector3.up * 0.8f, ForceMode.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isOnAir = true;

                JumpAudio.Play();

                CarRigidBody.AddForce(Vector3.up * 18, ForceMode.Impulse);
                //CarRigidBody.AddExplosionForce(1450, new Vector3(CarBody.transform.position.x, CarBody.transform.position.y - 0.5f, CarBody.transform.position.z), 5);
            }
        }

    }

}
