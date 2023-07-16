using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAuto : MonoBehaviour
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
    public float shootingRate =2f;
    public GameObject messageDisplay;
    public GameObject bulletDisplay;
    public AudioSource ReloadSound;
    
    public int reloadedBulletCounter = 0;
    public int bulletRest = 0;

    
    private void Start()
    {
        reloadedBulletCounter = 0;
        _cam = Camera.main.transform;
    }
    void Update()
    {
        bulletRest = reloadedBulletCounter;
        bulletDisplay.GetComponent<Text>().text = "" + (reloadedBulletCounter); //(30 - reloadedBulletCounter);

        if (Input.GetButtonDown("Fire1") && reloadedBulletCounter > 0)
        {
            if (IsFiring == false)
            {
                InvokeRepeating("Shooting", 0f, 1f / shootingRate);
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            IsFiring = false;
            CancelInvoke("Shooting");
        }

        else if (Input.GetButtonDown("Fire1") && reloadedBulletCounter <= 0)
        {
            if (IsFiring == false)
            {
                EmptyShot.Play();
                StartCoroutine(MessagDispl("No ammunition"));
            }
        }
        else if (Input.GetButton("Reload"))
        {
            if(SchmeisGlobalAmmo1.autoAmmoCount <= 0)
            {
                EmptyShot.Play();
                StartCoroutine(MessagDispl("No ammunition"));
            }
            else if(SchmeisGlobalAmmo1.autoAmmoCount > 0)
            {
                ReloadSound.Play();
                if(SchmeisGlobalAmmo1.autoAmmoCount >= 30)
                {
                    reloadedBulletCounter += (30 - reloadedBulletCounter);
                    SchmeisGlobalAmmo1.autoAmmoCount -= (30 - bulletRest);
                }
                else if(SchmeisGlobalAmmo1.autoAmmoCount < 30)
                {
                    if(reloadedBulletCounter + SchmeisGlobalAmmo1.autoAmmoCount <= 30)
                    {
                        reloadedBulletCounter += SchmeisGlobalAmmo1.autoAmmoCount;
                        SchmeisGlobalAmmo1.autoAmmoCount = 0;
                    }
                    else
                    {
                        reloadedBulletCounter += (30 - reloadedBulletCounter);
                        SchmeisGlobalAmmo1.autoAmmoCount -= (30 - bulletRest);
                    }
                }
                IsFiring = false;  
            }
        }
    }


    public void Shooting()
    {
        if (reloadedBulletCounter > 0)
        {
            StartCoroutine(FiringPistol());

        }

        else if (reloadedBulletCounter <= 0)
        {
            EmptyShot.Play();
            StartCoroutine(MessagDispl("Reload: R"));
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
        reloadedBulletCounter -= 1;
        TheGun.GetComponent<Animation>().Play("mp40Shooting");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        FlashPointLight.SetActive(true);
        GunFire.Play();
        yield return new WaitForSeconds(0.1f);
        FlashPointLight.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        IsFiring = false;       
    }

    IEnumerator MessagDispl(string text)
    {
        messageDisplay.SetActive(true);
        messageDisplay.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(1);
        messageDisplay.SetActive(false);
    }
}
