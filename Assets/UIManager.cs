using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI scoreUI;
    GameManager gm;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameoverscoreUI;
    [SerializeField] private TextMeshProUGUI recordscoreUI;
    private void Start()
    {
        gm= GameManager.Instance;
        gm.OnGameOver.AddListener(AcrivateGameOverUI);
    }

    public void playButtonHandler()
    {
        gm.StartGame();
      
        gm.currentScore = 0;

    }
    public void AcrivateGameOverUI()

    {  gameoverscoreUI.text = "Score " + gm.PrettyScore();
        recordscoreUI.text = "record " + gm.PrettyRecord();
        gameOverUI.SetActive(true);


    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
