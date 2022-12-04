using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "BuildingObject")]
public class BuildingObject : ScriptableObject
{
    public BuildingAction[] constructionActions;
    public string buildingName;
    public Sprite buildingSprite;
    public BlueprintObject buildingBlueprint;

    /*
    public GameObject prefab;
    //public Dictionary<Material.MatType, MatBlueprint> blueprint;
    public List<SerializedBlueprint> serializedBlueprints;
    public Dictionary<Material.MatType, List<MatBlueprint>> blueprint;
    
    public void SetUpDictionary()
    {
        blueprint = new Dictionary<Material.MatType,List<MatBlueprint>>();
        var MatBPList = SerializedBlueprintToMatBlueprint(serializedBlueprints);
        foreach (var bp in MatBPList)
        {
            if (!blueprint.ContainsKey(bp.baseMatType))
                blueprint.Add(bp.baseMatType, new List<MatBlueprint>());
            blueprint[bp.baseMatType].Add(bp);
        }
    }

    [System.Serializable]
    public class MatBlueprint
    {
        /*
         The Blueprint with referenmce to a specific material.  E.g. 

        R G
        B

        the R(Red) MatBluePrint will have a surrounding materials dictionary that looks like the following:
        (1,0) : Material.MatType.Green
        (0, -1) : Material.MatType.Blue

        //public Dictionary<Vector2Int, Material.MatType> surroundingMaterials;
        public Material.MatType baseMatType;
        public List<SurroundingMat> surroundingMaterials;

        public MatBlueprint(Material.MatType _baseMatType, List<SurroundingMat> _surroundingMaterials){
            baseMatType = _baseMatType;
            surroundingMaterials = _surroundingMaterials;
        }

    }

    #region CustomDictionaries
    //public Dictionary<Material.MatType, MatBlueprint> blueprint;
    //Substitute for above because unity does not allow dictionaries to be serialized
    [System.Serializable]
    public class SerializedBlueprint
    {
        public Material.MatType matType;
        public Vector2Int serializedCoords;
    }

    //public Dictionary<Vector2Int, Material.MatType> surroundingMaterials;
    //Substitute for above because unity does not allow dictionaries to be serialized
    [System.Serializable]
    public class SurroundingMat
    {
        public Vector2Int relativeCoord;
        public Material.MatType matType;
        public SurroundingMat (Vector2Int _relativeCoord, Material.MatType _matType)
        {
            relativeCoord = _relativeCoord;
            matType = _matType;
        }
    }
    #endregion

    private List<MatBlueprint> SerializedBlueprintToMatBlueprint(List<SerializedBlueprint> serialBps)
    {
        List<MatBlueprint> ret = new List<MatBlueprint>();
        for (int i = 0; i < serialBps.Count; i++)
        {
            List<SurroundingMat> surroundMatList = new List<SurroundingMat>();
            for (int j = 0; j < serialBps.Count; j++)
            {
                if (i == j)
                    continue;
                Vector2Int relCoord = serialBps[j].serializedCoords - serialBps[i].serializedCoords;
                surroundMatList.Add(new SurroundingMat(relCoord, serialBps[j].matType));
            }
            ret.Add(new MatBlueprint(serialBps[i].matType, surroundMatList));
        }
        return ret;
    }
    */
}
