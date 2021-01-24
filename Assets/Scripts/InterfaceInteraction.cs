using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceInteraction : MonoBehaviour
{

    /******************************************************************************
     * 
     * F O N C T I O N S   P O U R   L A   T R A N S I T I O N   D E
     * 
     * L ' I N T R O D U C T I O N   V E R S   L E   J E U
     * 
     * ***************************************************************************/

    public void IntroductionButton ()
    {
        StartCoroutine(IntroductionFunc());
    }


    public IEnumerator IntroductionFunc ()
    {
        // On arrête la musique de l'introduction
        ScenesManager.Inst.RemoveMusic();

        // On lance le son de validation pour l'appui sur le bouton
        ScenesManager.Inst.musicSource.clip = ((AudioClip)Resources.Load("Audio/Sounds/Validation"));
        ScenesManager.Inst.musicSource.Play();

        // On lance le fondu de sortie
        FadeTransition.Inst.PlayFadeOutAnimation();

        // le fondu dure 1 seconde, on attend
        yield return new WaitForSecondsRealtime(1);

        // On décharge la scène d'introduction
        SceneManager.UnloadSceneAsync("Title Scene", UnloadSceneOptions.None);

        // On lance le chargement de la scène de scrolling horizontal
        ScenesManager.Inst.SetSideScrollingScene();

        // On configure la musique pour la scène
        ScenesManager.Inst.musicSource.clip = ((AudioClip)Resources.Load("Audio/Musics/Inferno Galore"));
        ScenesManager.Inst.musicSource.loop = true;
        ScenesManager.Inst.musicSource.Play();

        // Lorsque la scène est chargée, on lance le fondu d'entrée
        FadeTransition.Inst.PlayFadeInAnimation();
    }


    /******************************************************************************
     * 
     * F O N C T I O N S   P O U R   L A   T R A N S I T I O N   D E   L A
     * 
     * P H A S E   D E   J E U   V E R S   L A   P H A S E   P L A T E
     * 
     * ***************************************************************************/

    public void SideScrollingToInfiniteButton ()
    {
        StartCoroutine(SideScrollingToInfiniteFunc());
    }

    public IEnumerator SideScrollingToInfiniteFunc ()
    {
        SceneManager.UnloadSceneAsync("UI Button Scene");

        // On décharge la scène de scrolling horizontal actuelle
        ScenesManager.Inst.UnloadSideScrollingScene();

        // On lance le fondu de sortie
        FadeTransition.Inst.PlayFadeOutAnimation();

        // le fondu dure 1 seconde, on attend
        yield return new WaitForSecondsRealtime(1);

        // On lance le chargement de la scène de scrolling horizontal
        ScenesManager.Inst.SetSideScrollingScene();
        yield return new WaitUntil(() => LevelGenerator.Inst != null);

        LevelGenerator.Inst.flatRoadGeneration = true;

        // Lorsque la scène est chargée, on lance le fondu d'entrée
        FadeTransition.Inst.PlayFadeInAnimation();

        SceneManager.UnloadSceneAsync("UI Button Scene", UnloadSceneOptions.None);
    }
}
