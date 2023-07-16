using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;
    public GameObject loadDots;
    public AudioSource buttonClick;
    public GameObject loadButton;
    public int loadInt;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loadInt = PlayerPrefs.GetInt("AutoSave");
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    public void QuitButton()
    {
        buttonClick.Play();
        Application.Quit();
    }

    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        loadText.GetComponent<Animation>().Play("LoadingTextAnim");
        loadDots.SetActive(true);
        loadDots.GetComponent<Animation>().Play("LoadingDotsAnim");
        SceneManager.LoadScene(2);
    }

    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    IEnumerator LoadGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        loadText.GetComponent<Animation>().Play("LoadingTextAnim");
        loadDots.SetActive(true);
        loadDots.GetComponent<Animation>().Play("LoadingDotsAnim");
        SceneManager.LoadScene(loadInt);
    }
}
