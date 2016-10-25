using UnityEngine;
using System.Collections;

public class ObstacleCollider : MonoBehaviour {

    private Rigidbody rb;
    public float fBulletStrength;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Bullet")
        {
            rb.isKinematic = false;

            Vector3 forceVec = -other.GetComponent<Rigidbody>().velocity.normalized * fBulletStrength;
            rb.AddForce(forceVec, ForceMode.Impulse);

            Destroy(this.gameObject,2.0f);
            Destroy(other.gameObject);
        }
    }
}
