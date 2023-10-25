using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text healthText;
    public Text ammoText;
    public Text cashText;
    public Text waveText;
    public playerStats player;
    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "[Health]: " + player.health;
        ammoText.text = "[Bullet]: " + player.currentGun.ammo + "/" + player.currentGun.maxAmmo;
        cashText.text = "[$Cash$]: $" + player.money;
        waveText.text = "[Wave]: " + spawner.wave;
    }
}
