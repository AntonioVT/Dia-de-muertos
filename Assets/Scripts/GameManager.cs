using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{

    public GameObject goPlayer;

    private UIManager uiManager;
    private FirstPersonSFX firstPersonSFX;

    public int iHealth = 100;

    public void Start()
    {
        uiManager = GetComponent<UIManager>();
        firstPersonSFX = goPlayer.GetComponent<FirstPersonSFX>();
    }

    public void DamagePlayer(int iDamage)
    {
        iHealth -= iDamage;
        uiManager.UpdateHealth(iHealth);
        uiManager.PlayDamageAnimation();
        firstPersonSFX.PlayHurtGroan();
    }

}
