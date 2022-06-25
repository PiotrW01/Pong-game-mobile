using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 1);
        }

        if(PlayerPrefs.GetInt("sound") == 2)
        {
            GameObject.Find("GameMusic").GetComponent<AudioSource>().mute = true;
            GameObject.Find("SoundButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("SoundOff");
        }

        if (SceneManager.GetActiveScene().name.Equals("Settings"))
        {
            if (PlayerPrefs.GetInt("size") == 1)
            {
                Button button = GameObject.Find("ButtonSizeBig").GetComponent<Button>();
                setButtonColorSelected(button);
            }
            else if (PlayerPrefs.GetInt("size") == -1)
            {
                Button button = GameObject.Find("ButtonSizeSmall").GetComponent<Button>();
                setButtonColorSelected(button);
            }
            else
            {
                Button button = GameObject.Find("ButtonSizeNormal").GetComponent<Button>();
                setButtonColorSelected(button);
            }
        }
    }


    public void ToggleMusic()
    {
        Image image = GameObject.Find("SoundButton").GetComponent<Image>();


            if (PlayerPrefs.GetInt("sound") == 1)
        {
            image.sprite = Resources.Load<Sprite>("SoundOff");
            PlayerPrefs.SetInt("sound", 2);
            GameObject.Find("GameMusic").GetComponent<AudioSource>().mute = true;
        }
                
        else
        {
            image.sprite = Resources.Load<Sprite>("SoundOn");
            PlayerPrefs.SetInt("sound", 1);
            GameObject.Find("GameMusic").GetComponent<AudioSource>().mute = false;
        }
        PlayerPrefs.Save();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChangePlatformSize()
    {
        
        var buttonEvent = EventSystem.current.currentSelectedGameObject;
        
        if (buttonEvent.name == "ButtonSizeBig")
        {
            PlayerPrefs.SetInt("size", 1);
            PlayerPrefs.Save();
            Button button = GameObject.Find(buttonEvent.name).GetComponent<Button>();
            setButtonColorSelected(button);

            Debug.Log(buttonEvent.name);
        }
        else if (buttonEvent.name == "ButtonSizeNormal")
        {
            PlayerPrefs.SetInt("size", 0);
            PlayerPrefs.Save();
            Button button = GameObject.Find(buttonEvent.name).GetComponent<Button>();
            setButtonColorSelected(button);

            Debug.Log(buttonEvent.name);
        }
        else if (buttonEvent.name == "ButtonSizeSmall")
        {
            PlayerPrefs.SetInt("size", -1);
            PlayerPrefs.Save();
            Button button = GameObject.Find(buttonEvent.name).GetComponent<Button>();
            setButtonColorSelected(button);

            Debug.Log(buttonEvent.name);
        }
    }

    void setButtonColorSelected(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = new Color(0.84f, 0.84f, 0.62f, 1);
        cb.selectedColor = new Color(0.84f, 0.84f, 0.62f, 1);
        cb.highlightedColor = new Color(0.84f, 0.84f, 0.62f, 1);
        button.colors = cb;
        buttonColorDeselectOther(button.name);
    }

    void buttonColorDeselectOther(string buttonName)
    {
        if (!buttonName.Equals("ButtonSizeBig"))
        {
            Button button = GameObject.Find("ButtonSizeBig").GetComponent<Button>();
            setButtonColorNotSelected(button);
        }
        if(!buttonName.Equals("ButtonSizeNormal"))
        {
            Button button = GameObject.Find("ButtonSizeNormal").GetComponent<Button>();
            setButtonColorNotSelected(button);
        }
        if(!buttonName.Equals("ButtonSizeSmall"))
        {
            Button button = GameObject.Find("ButtonSizeSmall").GetComponent<Button>();
            setButtonColorNotSelected(button);
        }
    }

    void setButtonColorNotSelected(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.white;
        cb.selectedColor = Color.white;
        cb.highlightedColor = Color.white;
        button.colors = cb;
    }
}
