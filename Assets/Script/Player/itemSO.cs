using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "itemSO", order = 1)]
public class itemSO : ScriptableObject
{
    [SerializeField] public Sprite itemImage;
    [SerializeField] public string name;
    [SerializeField] public int probabilityPercentage;
}
