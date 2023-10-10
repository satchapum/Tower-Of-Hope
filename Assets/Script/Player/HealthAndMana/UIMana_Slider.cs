using UnityEngine;
using UnityEngine.UI;

public class UIMana_Slider : UIManaPlayer
{
    [SerializeField] Slider manaSlider;

    public override void SetMana(int currentMana, int maxMana)
    {
        manaSlider.value = currentMana / (float)maxMana;
    }
}
