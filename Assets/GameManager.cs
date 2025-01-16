using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("--------hehehe_--")]
    public static GameManager Instance;
    
    #region Signleton
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    #endregion

    public data data;
    public float currentScore = 0F;
    public bool isPlaying=false;

    private void Start()
    {
        string loadedDAta = saveSystem.Load("save");
        if (loadedDAta != null)
        {
            data = JsonUtility.FromJson<data>(loadedDAta);
        }
        else
        {

            data = new data();
        }
    }
    public void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;


        }
    }
 public UnityEvent OnPlay =new UnityEvent();
    public UnityEvent OnGameOver =new UnityEvent();
public void StartGame()
    { if (isPlaying) {}
    OnPlay.Invoke();
        isPlaying = true;    
      
    }


   

    public void GameOver()
    {

        if (data.highscore < currentScore)
        {
            data.highscore = currentScore;
           string savestring= JsonUtility.ToJson(data);
            saveSystem.save("save", savestring);
        }
            OnGameOver.Invoke();
        
        isPlaying = false; 
     
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public string PrettyRecord()
    {
        return Mathf.RoundToInt(data.highscore).ToString();
    }
}
