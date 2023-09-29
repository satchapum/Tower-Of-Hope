using UnityEngine;
using UnityEngine.UI;

public class UIHealth_Slider : UIHealthPlayer
{
    [SerializeField] Slider healthSlider;

    public override void SetHealth(int currentHealth, int maxHealth)
    {
        healthSlider.value = currentHealth / (float)maxHealth;
    }
}
