using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------------------Adudio Source---------------")]
    [SerializeField] AudioSource musicSource;

    [Header("-------------------Adudio Clip---------------")]
    public AudioClip background;
    public bool ms = false;

    private void Start()
    {

       
            musicSource.clip = background;
            musicSource.Play();
            ms = true;
        
    }
}