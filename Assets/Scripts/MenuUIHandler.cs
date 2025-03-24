using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text bestScoreText; 
    public TMP_InputField nameInputField; 
    // If using TextMeshPro input field, use:
    // public TMP_InputField nameInput;

    private void Start()
    {
        int bestScore = DataManager.Instance.bestScore;
        string bestPlayer = DataManager.Instance.bestPlayerName;

        if (bestScore > 0 && !string.IsNullOrEmpty(bestPlayer))
        {
            bestScoreText.text = $"Best Score : {bestPlayer} : {bestScore}";
        }
        else
        {
            bestScoreText.text = "Best Score : 0";
        }
    }

    public void OnStartButtonClicked()
    {
        string playerName = nameInputField.text;
        
        // L’enregistrer dans ton DataManager
        DataManager.Instance.currentPlayerName = playerName;
        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }
}