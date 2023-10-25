using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float xRot;
    public float rotSpeed;

    public GameObject bullet;
    public Transform shootPoint;
    public float shootForce;
    public int ammo;
    public int maxAmmo;
    bool shooting;
    public float rateOfFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shoot();
    }

    public void RotateGun()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        xRot = mouseY * rotSpeed * Time.deltaTime;
        Vector3 gunRot = transform.rotation.eulerAngles;
        gunRot.x += xRot;
        gunRot.x = (gunRot.x > 180) ? gunRot.x - 360 : gunRot.x;
        gunRot.x = Mathf.Clamp(gunRot.x, -80, 80);
        transform.rotation = Quaternion.Euler(gunRot);
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0) && ammo > 0 && shooting == false)
        {
            StartCoroutine(FireBullet());
            CancelInvoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            InvokeRepeating("ReloadGun", 0.5f, 0.5f);
        }
    }

    IEnumerator FireBullet()
    {
        shooting = true;
        yield return new WaitForSeconds(rateOfFire);
        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(-shootPoint.forward * shootForce, ForceMode.Impulse);
        ammo--;
        shooting = false;
    }

    public void ReloadGun()
    {
        if (ammo < maxAmmo)
        {
            ammo += 10;
        }
        else
        {
            ammo = maxAmmo;
            CancelInvoke();
        }
    }
}
