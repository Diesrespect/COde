using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private const string ZOMBIE_TAG = "Zombie";

    public PlayerWeapons weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            if(_hit.collider.tag == ZOMBIE_TAG)
            {
                TakeShot(weapon.damage);
            }
        }
    }

    void TakeShot(int damage)
    {
        //_hit.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
    }

}
