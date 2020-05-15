using UnityEngine;

public class EnemyOnFoot : MonoBehaviour
{
    public Transform MainTarget;
    public GameObject EnemyBody;
    public Rigidbody EnemyRigidBody;

    public float speed;

    public Quaternion lookAt;

    private void FixedUpdate()
    {
        
        EnemyBody.transform.LookAt(MainTarget);

        EnemyBody.transform.rotation = Quaternion.Euler(0, EnemyBody.transform.rotation.eulerAngles.y, 0);

        if (EnemyRigidBody.velocity.magnitude > 6 ) { 
            EnemyRigidBody.AddRelativeForce(-Vector3.forward * speed, ForceMode.Impulse);
        } else
        {
            EnemyRigidBody.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        }

    }

}
