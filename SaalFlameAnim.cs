using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaalFlameAnim : MonoBehaviour
{
    public int LightMode;
    public GameObject FlameLight;

    void Update()
    {
        if (LightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    IEnumerator AnimateLight()
    {
        LightMode = Random.Range(1, 4);
        if (LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("LustraSaalAnim");
        }

        LightMode = Random.Range(1, 4);
        if (LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("LustraSaalAnim02");
        }

        LightMode = Random.Range(1, 4);
        if (LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("LustraSaalAnim03");
        }

        yield return new WaitForSeconds(1);

        LightMode = 0;
    }
}
