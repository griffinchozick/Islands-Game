using System;

[Serializable]
public class Blueprint
{
    public int BlueprintDimensions = 3;
    public Material.MatType[] FlattenedGrid;
    public Blueprint() {
        FlattenedGrid = new Material.MatType[BlueprintDimensions * BlueprintDimensions];
    }
}
