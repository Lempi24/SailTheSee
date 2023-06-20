using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    [SerializeField] private AudioSource smierc;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;        
    }


    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        smierc.Play();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
