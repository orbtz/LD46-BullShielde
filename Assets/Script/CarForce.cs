using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForce : MonoBehaviour
{

    public Rigidbody CarRigidBody;
    public GameObject CarBody;
    public Transform NextRoute;

    public Vector3 NextRouteVector;
    public Vector3 NextRouteVectorNN;

    // Eixo Y para rotacionar as rodas para o lado
    public GameObject FrontWheelL;
    public GameObject FrontWheelR;

    public GameObject FrontAxis;

    public Quaternion WheelRotation;

    public int CarSpeed;

    public bool WillMove;

    public EscortLife Life;
    public bool isDying = false;

    public bool WillShoot;
    public bool isShooting;
    public GameObject TargetAim;
    public float MinRange;
    public bool CanShoot;
    public GameObject Projectile;
    public GameObject ProjectileInScene;

    public MasterTimeData TimeData;
    public CameraShake Shake;

    private void Start()
    {
        WillMove = true;

        NextRouteVector = NextRoute.position - this.transform.position;

        NextRouteVectorNN = NextRouteVector;
        NextRouteVector = NextRouteVector.normalized;
    }

    private void Update()
    {
        if (WillShoot == true)
        {
           if (Vector3.Distance(NextRoute.position, CarRigidBody.transform.position) < MinRange)
            {
                CanShoot = true;
                WillMove = false;
            } else
            {
                CanShoot = false;
            }
        }

        if (CanShoot == true && isShooting == false)
        {
            isShooting = true;
            StartCoroutine("Shoot");
        }
    }

    private void FixedUpdate()
    {

        if (Life.isDead == false)
        {
            NextRouteVector = NextRoute.position - CarBody.transform.position;
            NextRouteVectorNN = NextRouteVector;
            NextRouteVector = NextRouteVector.normalized;

            if (WillMove == true && TimeData.willSlowTime == false)
            {
                WheelRotation = Quaternion.LookRotation(NextRouteVector, Vector3.up);
                FrontAxis.transform.rotation = Quaternion.Slerp(FrontAxis.transform.rotation, WheelRotation, Time.fixedDeltaTime * 30.0f);

                CarRigidBody.AddForce(NextRouteVector * CarSpeed, ForceMode.Impulse);

            }

        } else
        {

            //Debug.Log("oi");
            if (isDying == false)
            {
                StartCoroutine("Dying");
            }
        }
        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(2);
        ProjectileInScene = Instantiate(Projectile, CarRigidBody.transform.position, CarRigidBody.transform.rotation);

        ProjectileInScene.GetComponent<ProjectileData>().Origin = CarRigidBody.gameObject;

        CarRigidBody.AddForce( -(TargetAim.transform.position - ProjectileInScene.transform.position) * 10, ForceMode.Impulse);

        ProjectileInScene.GetComponent<Rigidbody>().AddForce( (TargetAim.transform.position - ProjectileInScene.transform.position) * 0.6f, ForceMode.Impulse);
        ProjectileInScene.GetComponent<Rigidbody>().AddForce(Vector3.up * 25, ForceMode.Impulse);

        
        yield return new WaitForSecondsRealtime(2.5f);
        WillMove = true;

        isShooting = false;
    }

    IEnumerator Dying()
    {
        isDying = true;
        yield return new WaitForSecondsRealtime(1);
        CarRigidBody.AddForce(Vector3.up * Random.Range(750, 2000), ForceMode.Impulse);

        //Shake.enabled = true;

        Destroy(this.gameObject, 3);
    }


}
