using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text errorMessage;

    public string correctEmail = "conanlim2007@gmail.com";
    public string correctPassword = "1234";


    public void CheckPassword()
    {
        if (passwordInput.text == correctPassword && emailInput.text == correctEmail)
        {
            SceneManager.LoadScene(0);
            errorMessage.gameObject.SetActive(false);
        }
        else
        {
            errorMessage.text = "Wrong password!";
            errorMessage.gameObject.SetActive(true);
        }
    }
}
