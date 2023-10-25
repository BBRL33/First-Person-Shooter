using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeScript : MonoBehaviour
{
    public float xRot;
    public float rotSpeed;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
        SwingWeapon();
    }

    public void SwingWeapon()
    {
        if(Input.GetMouseButtonDown(0))
        {
            attacking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
            attacking = false;
        }
    }

    public void RotateWeapon()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        xRot = mouseY * rotSpeed * Time.deltaTime;
        Vector3 gunRot = transform.rotation.eulerAngles;
        gunRot.x += xRot;
        gunRot.x = (gunRot.x > 180) ? gunRot.x - 360 : gunRot.x;
        gunRot.x = Mathf.Clamp(gunRot.x, -80, 80);
        transform.rotation = Quaternion.Euler(gunRot);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.gameObject.GetComponent<AiEnemy>())
        {
            if(attacking == true)
            {
                collision.gameObject.gameObject.GetComponent<AiEnemy>().health -= 1;
            }
        }
    }
}
