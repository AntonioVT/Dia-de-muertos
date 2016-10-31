using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    public float fInterval = 0.5f;
    private float fNextInterval = 0.0f;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(Time.time > fNextInterval)
            {
                fNextInterval = Time.time + fInterval;
                int iDamage = Random.Range(1, 7);
                gameManager.DamagePlayer(iDamage);
            }
            
        }
    }
}
