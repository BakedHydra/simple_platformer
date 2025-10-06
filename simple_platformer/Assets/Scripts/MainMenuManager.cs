using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Settings;

    private void Start() 
    { 
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Exit_script()
    {
        Application.Quit();
    }
    public void ToGame_script()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ToSettings_script()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
    }
    public void ToMainMenu()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
    }
}
