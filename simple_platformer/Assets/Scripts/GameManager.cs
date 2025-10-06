using TMPro;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    [SerializeField] private GameObject GameMenu;
    [SerializeField] private GameObject PlayerUI;
    [SerializeField] private GameObject DeathMenu;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject Settings;
    [SerializeField] private TMP_Text PlayerUICoin;
    [SerializeField] private TMP_Text PlayerUIHealth;
    [HideInInspector] public int coin_amount;
    [HideInInspector] public int coin_counter;
    [HideInInspector] public int health;
    public void Start()
    {
        GameMenu.SetActive(false);
        PlayerUI.SetActive(true);
        DeathMenu.SetActive(false);
        WinMenu.SetActive(false);
        Settings.SetActive(false);

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Coin");
        coin_amount = gameObjects.Length;
        health = 3;
        Time.timeScale = 1f;
    }
    public void Update()
    {
        PlayerUICoin.text = coin_counter.ToString() + " / " + coin_amount.ToString();
    }
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.Escape)
            {
                if (GameMenu.activeSelf)
                {
                    ToGame_script();
                    return;
                }
                else
                {
                    ToGameMenu_script();
                    return;
                }
            }
        }
    }
    public void ToMainMenu_script()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToGame_script()
    {
        Time.timeScale = 1.0f;
        GameMenu.SetActive(false);
        PlayerUI.SetActive(true);
    }
    public void ToGameMenu_script()
    {
        Time.timeScale = 0f;
        GameMenu.SetActive(true);
        PlayerUI.SetActive(false);
    }
    public void PlayerReceivedDamage_script()
    {
        health--;
        if (health == 0)
        {
            ToDeathMenu_script();
            return;
        }
        PlayerUIHealth.text = PlayerUIHealth.text.Remove(PlayerUIHealth.text.Length - 1);
    }
    public void ToDeathMenu_script()
    {
        Time.timeScale = 0f;
        PlayerUI.SetActive(false);
        DeathMenu.SetActive(true);
    }
    public void RestartLevel_script()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ToWin_script()
    {
        Time.timeScale = 0f;
        PlayerUI.SetActive(false);
        WinMenu.SetActive(true);
    }
    public void ToSettings_script(GameObject parent)
    {
        parent.SetActive(false);
        Settings.SetActive(true);
    }
    public void FromSettings_script(GameObject parent)
    {
        parent.SetActive(true);
        Settings.SetActive(false);
    }
}
