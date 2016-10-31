using UnityEngine;
using System.Collections;

public class FirstPersonShooter : MonoBehaviour {

    private FirstPersonSFX firstPersonSFX;
        
    public Transform[] tGunpoint;
    public Animation[] animGuns;
    public GameObject prefBullet;
    public float fForce;
    public float fBulletLifeTime = 1.3333f;
    public int iDistance;
    private int iGunPoint = 0;

    void Start()
    {
        firstPersonSFX = GetComponent<FirstPersonSFX>();
    }
	
	
	void Update () {
        //Debug.DrawRay(tGunpoint.position, tGunpoint.forward * iDistance);

        if (Input.GetButtonDown("Fire1"))
        {
            // Adm. de efectos de sonido
            firstPersonSFX.PlayGunShot();

            //Animar
            this.AnimateGuns();

            // Disparar proyectil
            this.Shoot();
            
            // Actualizar pistolas
            iGunPoint++;
            iGunPoint = iGunPoint % 2;
        }
    }

    void AnimateGuns()
    {
        Animation anim = animGuns[iGunPoint];
        if (anim.isPlaying)
        {
            anim.Stop();
            anim.Sample();
            anim.enabled = false;
        }
        anim.enabled = true;
        animGuns[iGunPoint].Play();
    }

    void Shoot()
    {
        // Crear instancia proyectil
        GameObject goBullet = Instantiate(prefBullet, tGunpoint[iGunPoint].position, transform.rotation) as GameObject;

        // Dar fuerza al proyectil
        Rigidbody bulletRb = goBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(tGunpoint[iGunPoint].forward * fForce, ForceMode.Force);

        // Destruir el proyectil en X segundos
        Bullet bulletScript = goBullet.GetComponent<Bullet>();
        bulletScript.StartCoroutine(bulletScript.BulletAliveTime(fBulletLifeTime));
    }
}
