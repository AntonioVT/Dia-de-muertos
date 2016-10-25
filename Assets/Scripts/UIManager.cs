using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Text tHealth;

	public void UpdateHealth(int iHealth)
    {
        tHealth.text = "Vida: " + iHealth;
    }
}
