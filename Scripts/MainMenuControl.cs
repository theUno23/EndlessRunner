using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{

    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject bounceText;
    [SerializeField] GameObject bigButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControls;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam());
    }

    public void StartGame()
    {
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton() 
    {
        if (fadeOut != null)
        {
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(1);
    }

    IEnumerator AnimCam()
    {
        animCam.GetComponent<Animator>().Play("AnimMenuCam");
        bounceText.SetActive(false);
        bigButton.SetActive(false);

        yield return new WaitForSeconds(3f);

        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControls.SetActive(true);

    }
}
