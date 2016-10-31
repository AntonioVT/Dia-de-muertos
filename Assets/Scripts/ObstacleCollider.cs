using UnityEngine;
using System.Collections;

public class ObstacleCollider : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject goExplosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            rb.isKinematic = false;

            Bullet bBullet = other.gameObject.GetComponent<Bullet>();
            bBullet.SpawnExplosion();

            Vector3 forceVec = -other.GetComponent<Rigidbody>().velocity.normalized * bBullet.fBulletStrength;
            rb.AddForce(forceVec, ForceMode.Impulse);

            

            StartCoroutine(DestroyAndSpawn());
        }
    }

    IEnumerator DestroyAndSpawn()
    {
        yield return new WaitForSeconds(2.0f);
        // Crear explosion
        GameObject goExpl = Instantiate(goExplosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(goExpl, 2.0f);
        Destroy(this.gameObject);
    }
}
