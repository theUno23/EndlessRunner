using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{

    [SerializeField]
    GameObject thePlayer;

    [SerializeField]
    GameObject playerAnim;

    [SerializeField]
    AudioSource collisionFX;

    [SerializeField]
    GameObject mainCam;

    [SerializeField]
    GameObject fadeOut;

    [SerializeField]
    GameObject distanceCounter; // Reference to the object with LevelDistance component

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CollisionEnd());
    }


    IEnumerator CollisionEnd()
    {
        collisionFX.Play();
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards");
        //mainCam.GetComponent<Animator>().Play("CollisionCam");
        //yield return new WaitForSeconds(3);
        //fadeOut.SetActive(true);
        
        // Stop the distance counter
        if (distanceCounter != null)
        {
            distanceCounter.GetComponent<LevelDistance>().enabled = false;
        }
        
        yield return new WaitForSeconds(4);
        
        // Reset counters before reloading scene
        LevelDistance.disRun = 0;
        MasterInfo.coinCount = 0;
        
        SceneManager.LoadScene(0);
    }
}
