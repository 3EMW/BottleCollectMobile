using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator layoutAnimator;
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Background;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;
    private int score, highScore;
    public TextMeshProUGUI scoreText, highScoreText;
    /*
    public GameObject noAds;
    public TextMeshProUGUI coinText;
    */

    private void Awake()
    {
        CheckSettings();
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            //NoAdsRemove();
        }
        //CoinTextUpdate();
    }

    public void FirstTouch()
    {
        //noAds.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Background.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }
    /*
    public void NoAdsRemove()
    {
        noAds.SetActive(false);
    }
    public void CoinTextUpdate()
    {
        coinText.text = PlayerPrefs.GetInt("moneys").ToString();
    }
    */
    public void Privacy_Policy()
    {
        Application.OpenURL("https://www.website.com/privacy_policy/");
    }
    public void TermOfUse()
    {
        Application.OpenURL("https://www.website.com/term_of_use/");
    }

    private void CheckSettings()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }
    }

    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        layoutAnimator.SetTrigger("slide_in");
    }
    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        layoutAnimator.SetTrigger("slide_out");
    }
    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }
    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }

}
