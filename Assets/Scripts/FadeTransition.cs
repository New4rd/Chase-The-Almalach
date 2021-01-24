using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    static private FadeTransition _inst;
    static public FadeTransition Inst
    {
        get { return _inst; }
    }


    [SerializeField] public Animator fadeAnimator;
    [SerializeField] public Image fadeImage;


    private void Awake()
    {
        _inst = this;
    }


    public void PlayFadeInAnimation ()
    {
        fadeAnimator.SetTrigger("FadeInTrigger");
    }


    public void PlayFadeOutAnimation ()
    {
        fadeAnimator.SetTrigger("FadeOutTrigger");
    }


    public void SetBlackScreen ()
    {
        fadeImage.color = new Color32(0, 0, 0, 1);
    }


    public void SetCleanScreen ()
    {
        fadeImage.color = new Color32(0, 0, 0, 0);
    }
}
