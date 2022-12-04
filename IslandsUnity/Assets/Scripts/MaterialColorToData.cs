using UnityEngine;

[CreateAssetMenu(fileName = "MaterialColorToData", menuName = "MaterialColorToData")]
public class MaterialColorToData : ScriptableObject
{
    [SerializeField] MaterialObject blue;
    [SerializeField] MaterialObject purple;
    [SerializeField] MaterialObject red;
    [SerializeField] MaterialObject yellow;

    public MaterialObject GetData(MaterialColor color)
    {
        if (color == MaterialColor.Blue)
            return blue;
        else if (color == MaterialColor.Purple)
            return purple;
        else if (color == MaterialColor.Red)
            return red;
        else if (color == MaterialColor.Yellow)
            return yellow;
        else
        {
            Debug.LogWarning("Invalid Material Color parameter for function ColorToList()");
            return null;
        }
    }
}
