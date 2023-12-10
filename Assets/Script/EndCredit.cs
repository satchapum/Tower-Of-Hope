using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndCredit : MonoBehaviour
{
    [SerializeField] TMP_Text textInstance;

    [SerializeField] float speedPxPerFrame;

    void ResetCreditPosition()
    {
        float textHeightPx = LayoutUtility.GetPreferredHeight(this.textInstance.rectTransform);
        this.textInstance.rectTransform.offsetMin = new Vector2(0, -textHeightPx);
        this.textInstance.rectTransform.offsetMax = new Vector2(0, -Screen.height);
    }
    private void Start()
    {
        RestartCredit();
    }
    void FixedUpdate()
    {
        if (this.textInstance.rectTransform.offsetMax.y <= Screen.height )
        {
            this.textInstance.rectTransform.Translate(new Vector2(0, this.speedPxPerFrame));
        }
    }

    public void RestartCredit()
    {
        ResetCreditPosition();
    }
}