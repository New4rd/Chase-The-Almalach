using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchedObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (transform.tag)
        {
            case ("Music Tape"):
                CarState.Inst.music = true;
                CarState.Inst.carAnim.SetBool("Music", true);
                ScenesManager.Inst.effectSource.clip = ((AudioClip)Resources.Load("Audio/Sounds/Item Collect"));
                ScenesManager.Inst.effectSource.Play();
                ScoreManager.Inst.AddPoints(1000);
                ItemSpawnHandler.musicSpawnProbability = 0;
                break;

            case ("Convector"):
                CarState.Inst.convector = true;
                CarState.Inst.carAnim.SetBool("Convector", true);
                ScenesManager.Inst.effectSource.clip = ((AudioClip)Resources.Load("Audio/Sounds/Item Collect"));
                ScenesManager.Inst.effectSource.Play();
                ScoreManager.Inst.AddPoints(1000);
                ItemSpawnHandler.convectorSpawnProbability = 0;
                break;

            case ("Uranium"):
                CarState.Inst.uranium = true;
                CarState.Inst.carAnim.SetBool("Uranium", true);
                ScenesManager.Inst.effectSource.clip = ((AudioClip)Resources.Load("Audio/Sounds/Item Collect"));
                ScenesManager.Inst.effectSource.Play();
                ScoreManager.Inst.AddPoints(1000);
                ItemSpawnHandler.uraniumSpawnProbability = 0;
                break;
        }
        
        //ScenesManager.Inst.DisplayPopup("Popup Scene", 2f);
        gameObject.SetActive(false);
        
        if (CarState.Inst.convector && CarState.Inst.music && CarState.Inst.uranium && !ScenesManager.Inst.UIButtonLoaded)
        {
            SceneManager.LoadSceneAsync("UI Button Scene", LoadSceneMode.Additive);
            ScenesManager.Inst.UIButtonLoaded = true;
        }
    }
}
