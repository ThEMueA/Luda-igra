using System.Runtime.CompilerServices;
using UnityEngine;

public class ColisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        GameManager.Instance.OnPlay.AddListener(ActivatePlayer);
    }
    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.transform.tag == "obsticle")
        {
           gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }
}
