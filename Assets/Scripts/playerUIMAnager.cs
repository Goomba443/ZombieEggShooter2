using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerUIMAnager : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject gameplayUI;
    private TextMeshProUGUI txtHealth;
    private TextMeshProUGUI txtEggs;
    private Weapon weapon;
    public Button playAgainBtn;

    // Start is called before the first frame update
    void Start()
    {
        txtHealth = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        txtEggs = GameObject.Find("EggsLeft").GetComponent<TextMeshProUGUI>();
        txtHealth.text = "Vida: " + PlayerHealth.maxHealth.ToString();
        txtEggs.text = "Huevos: " + Weapon.cargador.ToString();
        playAgainBtn.onClick.AddListener(StartOver);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (PlayerHealth.playerHealth > 0)
        {
            txtHealth.text = "Vida: " + PlayerHealth.playerHealth.ToString();
        } else
        {
            //txtHealth.text = "ES INFINITA PQ AHORA ERES UN ZOMBIE";
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameplayUI.gameObject.SetActive(false);
            deathScreen.gameObject.SetActive(true);
        }
        if(Weapon.cargador > 0)
        {
            txtEggs.text = "Huevos: " + Weapon.cargador.ToString();
        } else
        {
            txtEggs.text = "Pulsa 'R' para recargar";
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
