using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe destinée aux opérations de chargement/déchargement des différentes scènes,
/// et à leur configuration (SINGLETON).
/// </summary>

public class ScenesManager : MonoBehaviour
{
    static private ScenesManager _inst;
    static public ScenesManager Inst
    {
        get { return _inst; }
    }

    private bool _UIButtonLoaded;
    public bool UIButtonLoaded
    {
        set { _UIButtonLoaded = value; }
        get { return _UIButtonLoaded; }
    }

    /// <summary>
    /// Source audio destinée à la configuration audio de la musique au sein des fonctions.
    /// </summary>
    [SerializeField] public AudioSource musicSource;

    /// <summary>
    /// Source audio destinée à la configuration audio des sons au sein des fonctions.
    /// </summary>
    [SerializeField] public AudioSource effectSource;

    /// <summary>
    /// Booléen décidant si l'introduction doit être jouée (Debug uniquement).
    /// </summary>
    [SerializeField] public bool playIntro;


    private void Awake()
    {
        _inst = this;
        _UIButtonLoaded = false;
    }


    private void Start()
    {
        StartCoroutine(LaunchGame());
    }

    
    public IEnumerator LaunchGame ()
    {
        FadeTransition.Inst.PlayFadeInAnimation();

        SceneManager.LoadSceneAsync("Intro 1 Scene", LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(3.65f);

        SceneManager.UnloadSceneAsync("Intro 1 Scene", UnloadSceneOptions.None);
        SceneManager.LoadSceneAsync("Intro 2 Scene", LoadSceneMode.Additive);

        yield return new WaitForSecondsRealtime(3.65f);

        SceneManager.UnloadSceneAsync("Intro 2 Scene", UnloadSceneOptions.None);
        SceneManager.LoadSceneAsync("Title Scene", LoadSceneMode.Additive);
    }


    public void SetSideScrollingScene ()
    {
        // On charge la scène de scrolling horizontal
        SceneManager.LoadSceneAsync("Side Scrolling Scene", LoadSceneMode.Additive);

        // On charge la scène de score
        SceneManager.LoadSceneAsync("UI Score Scene", LoadSceneMode.Additive);
    }


    public void UnloadSideScrollingScene ()
    {
        // On décharge la scène de scrolling vertical
        SceneManager.UnloadSceneAsync("Side Scrolling Scene", UnloadSceneOptions.None);

        // On décharge la scène de score
        //SceneManager.UnloadSceneAsync("UI Score Scene", UnloadSceneOptions.None);
    }


    public IEnumerator DisplayPopup (string sceneName, float duration)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(duration);
        SceneManager.UnloadSceneAsync(sceneName);
    }


    public void RemoveMusic ()
    {
        musicSource.clip = null;
    }


    public void RemoveSound ()
    {
        effectSource.clip = null;
    }
}
