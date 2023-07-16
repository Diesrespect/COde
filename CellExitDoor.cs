using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CellExitDoor : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject fadeOut;

    void Update()
    {
        TheDistance = PlayerCast1sc.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {
            ActionText.GetComponent<Text>().text = "open the door";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }

        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                fadeOut.SetActive(true);
                StartCoroutine(FaidToExit());
                //TheDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                //CreakSound.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

    IEnumerator FaidToExit()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }
}
