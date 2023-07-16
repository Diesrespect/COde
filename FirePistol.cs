using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public GameObject FlashPointLight;
    public AudioSource GunFire;
    public AudioSource EmptyShot;
    public static bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;
    private Transform _cam;

    public GameObject bulletDisplay;
    public GameObject messageDispl;

    public AudioSource reloadSound;

    public int bulletPistCounter = 0;
    public int bulletRest = 0;



    void Start()
    {
        
        //bulletPistCounter = 0;
        _cam = Camera.main.transform;
    }
    void Update()
    {
        bulletRest = bulletPistCounter;
        bulletDisplay.GetComponent<Text>().text = "" + (bulletPistCounter);

        if(Input.GetButtonDown("Fire1") && bulletPistCounter > 0)
        {
            if(IsFiring == false)
            {
                //PistolGlobalAmmo.pistAmmoCount -= 1;
                //bulletPistCounter -= 1;
                StartCoroutine(FiringPistol());
            }
        }

        else if (Input.GetButtonDown("Fire1") && bulletPistCounter <= 0)
        {
            if (IsFiring == false)
            {
                StartCoroutine(MessagDispl("No ammunition"));
                EmptyShot.Play();
            }
        }
        

        else if (Input.GetButton("Reload"))
        {
            if (PistolGlobalAmmo.pistAmmoCount <= 0)
            {
                EmptyShot.Play();
                StartCoroutine(MessagDispl("No ammunition"));
            }
            else if (PistolGlobalAmmo.pistAmmoCount > 0)
            {
                reloadSound.Play();
                if (PistolGlobalAmmo.pistAmmoCount >= 8)
                {
                    bulletPistCounter += (8 - bulletPistCounter);
                    PistolGlobalAmmo.pistAmmoCount -= (8 - bulletRest);
                }
                else if (PistolGlobalAmmo.pistAmmoCount < 8)
                {
                    if (bulletPistCounter + PistolGlobalAmmo.pistAmmoCount <= 8)
                    {
                        bulletPistCounter += PistolGlobalAmmo.pistAmmoCount;
                        PistolGlobalAmmo.pistAmmoCount = 0;
                    }
                    else
                    {
                        bulletPistCounter += (8 - bulletPistCounter);
                        PistolGlobalAmmo.pistAmmoCount -= (8 - bulletRest);
                    }
                }
                IsFiring = false;
            }
        }
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
        bulletPistCounter -= 1;
        TheGun.GetComponent<Animation>().Play("PistolShooting");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        FlashPointLight.SetActive(true);
        GunFire.Play();
        yield return new WaitForSeconds(0.1f);
        FlashPointLight.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        IsFiring = false;
    }

    IEnumerator MessagDispl(string text)
    {
        messageDispl.SetActive(true);
        messageDispl.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(1);
        messageDispl.SetActive(false);
    }

   
}
