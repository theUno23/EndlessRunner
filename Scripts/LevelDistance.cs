using System.Collections;
using UnityEngine;
using TMPro;  

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public static int disRun = 0;
    private bool addingDis = false;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (!addingDis && playerMovement != null && playerMovement.enabled)
        {
            addingDis = true;
            StartCoroutine(disCounter());
        }    
    }

    IEnumerator disCounter()
    {
        disRun += 1;
        disDisplay.GetComponent<TMP_Text>().text = "DISTANCE: " + disRun.ToString();
        yield return new WaitForSeconds(0.25f);
        addingDis = false;  
    }
}
