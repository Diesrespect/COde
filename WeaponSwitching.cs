using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    //public GameObject autoAmmoDisplay;
    //public GameObject pistAmmoDisplay;
    public AudioSource gunSwitching;
    
    public int selectedWeapon = 0;
  
    void Start()
    {
        SelectWeapon();
    }

    
    void Update()
    {

        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            gunSwitching.Play();
            if (selectedWeapon >= transform.childCount - 1)
            {

                selectedWeapon = 0;
                //autoAmmoDisplay.SetActive(false);
                //pistAmmoDisplay.SetActive(true);
            }

            else
            {
                selectedWeapon++;
                //autoAmmoDisplay.SetActive(true);
                //pistAmmoDisplay.SetActive(false);
            }
                
        }
        
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            gunSwitching.Play();
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunSwitching.Play();
            selectedWeapon = 0;
        } 
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            gunSwitching.Play();
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)
        {
            gunSwitching.Play();
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 2)
        {
            gunSwitching.Play();
            selectedWeapon = 3;
        }

        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                
                weapon.gameObject.SetActive(true);
                FirePistol.IsFiring = false;
                FireAuto.IsFiring = false;
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
