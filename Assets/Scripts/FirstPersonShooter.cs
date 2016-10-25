using UnityEngine;
using System.Collections;

public class FirstPersonShooter : MonoBehaviour {

    public GameObject prefBullet;
    public Transform tGunpoint;
    public float fForce;
    public int iDistance;
	
	// Update is called once per frame
	void Update () {
        //Debug.DrawRay(tGunpoint.position, tGunpoint.forward * iDistance);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject goBullet = Instantiate(prefBullet, tGunpoint.position, Quaternion.identity) as GameObject;
            Rigidbody bulletRb = goBullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(tGunpoint.forward * fForce, ForceMode.Force);
        }
    }
}
