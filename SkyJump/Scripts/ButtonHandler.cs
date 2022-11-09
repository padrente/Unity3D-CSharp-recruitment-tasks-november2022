using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] Button pause;
    [SerializeField] Button resume;
    [SerializeField] Button restart;

    


    public void Pause()
    {
        pause.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pause.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResetScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SkyJump");
    }
}
