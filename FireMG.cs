using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMG : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public GameObject FlashPointLight;
    public AudioSource GunFire;
    //public AudioSource EmptyShot;
    public static bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 10;
    public Transform _cam;
    public float shootingRate =2f;


    private void Start()
    {
        //_cam = Camera.main.transform;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(IsFiring == false)
            {
                
                //Debug.Log("start");
                InvokeRepeating("Shooting", 0f, 1f/shootingRate);
            }
        } else if (Input.GetButtonUp("Fire1"))
        {
            TheGun.GetComponent<Animator>().Play("MG_Idle");
            GunFire.Stop();
            IsFiring = false;
            CancelInvoke("Shooting");
        }
    }


    public void Shooting()
    {
         StartCoroutine(FiringPistol());
    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;
        IsFiring = true;
        if (Physics.Raycast(_cam.position, _cam.forward, out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        
        //SchmeisGlobalAmmo1.autoAmmoCount -= 1;
        TheGun.GetComponent<Animator>().Play("MG_Anim");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleMG");
        FlashPointLight.SetActive(true);
        GunFire.Play();
        yield return new WaitForSeconds(0.1f);
        FlashPointLight.SetActive(false);
        
        yield return new WaitForSeconds(0.1f);
        
        IsFiring = false;
    }
}
