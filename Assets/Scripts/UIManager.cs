using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Text tHealth;
    public GameObject goDamagePanel;

    void Start()
    {
        SetObjectsMode();
    }

    public void SetObjectsMode()
    {
        goDamagePanel.SetActive(false);
    }


    public void UpdateHealth(int iHealth)
    {
        tHealth.text = "Vida: " + iHealth;
    }

    public void PlayDamageAnimation()
    {
        goDamagePanel.SetActive(false);
        goDamagePanel.SetActive(true);
    }

}
