using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    private UIManager uiManager;

    public int iHealth = 100;

    public void Start()
    {
        uiManager = GetComponent<UIManager>();
    }

    public void DamagePlayer(int iDamage)
    {
        iHealth -= iDamage;
        uiManager.UpdateHealth(iHealth);
    }

}
