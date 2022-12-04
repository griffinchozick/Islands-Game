using System.Collections;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    public Island allyIsland;
    public Island enemyIsland;
    public Island currentIsland;
    public Vector2Int selectedCoords = new Vector2Int (2,2);
    bool selectingEnemy = false;

    [SerializeField] SpriteRenderer selectorSprite;

    private ControllerState currentState = null;
    public ControllerState placeMaterialState = new PlaceMaterialControllerState();
    public ControllerState attackState = new AttackControllerState();
    //public ControllerState defenseBuffState;

    public Building activeBuilding = null;


    public BuildingDeckManager buildingDeckManager;
    public AirdropPreview airdropPreview;
    public BuildingChecker buildingChecker;

    [SerializeField] GameObject buildingPrefab;

    public GameManager gameManager;
    private Coroutine airdropTimerRef;
    private float autoplaceCooldown  = 5f;
    private int timerUpdateRate = 64;

    private void Start()
    {
        currentIsland = allyIsland;
        currentState = placeMaterialState;
        MoveSelector();
        airdropTimerRef = StartCoroutine(AirdropTimer());
    }

    public void SwitchState(ControllerState newState)
    {
        Debug.Log(newState);
        if (currentState == newState)
            return;
        currentState = newState;
        newState.EnterState(this);
    }

    public void MainAction()
    {
        if (gameManager.gameOver)
            return;
        bool result = currentState.MainAction(this);
        if (result)
            gameManager.CheckGameOver();
    }
    public void SwitchIslands(Island newIsland)
    {
        Debug.Log(newIsland);
        currentIsland = newIsland;
        MoveSelector();
    }

    /*public void StartTimedAction(float actionTime, System.Action<IslandController> TimeUpAction)
    {
        if (timingAction)
        {
            Debug.LogWarning("Already timing action!!!");
            return;
        }
        timedActionCallback = TimeUpAction;
        StartCoroutine(TimedAction(actionTime));
    }
    private IEnumerator TimedAction(float actionTime)
    {
        yield return new WaitForSeconds(actionTime);
        CompletedTimedAction();
    }

    void CompletedTimedAction()
    {
        if (!timingAction)
        {
            timedActionCallback
        }
    }*/


    #region SelectorLogic
    public void MoveSelector(Vector2Int target)
    {
        if (gameManager.gameOver)
            return;
        if (!currentIsland.OnGrid(target))
        {
            Debug.LogWarning("Trying to move off the grid");
            return;
        }
        selectedCoords = target;
        UpdateSelectorSprite(selectedCoords);
    }
    //MoveSelector() Justs sets selector to default position
    public void MoveSelector() => MoveSelector(new Vector2Int(2, 2));
    public void MoveSelectorDirection(Vector2Int direction) => MoveSelector(direction + selectedCoords);

    public void UpdateSelectorSprite(Vector2Int location)
    {
        if (!selectorSprite.enabled)
            selectorSprite.enabled = true;
        selectorSprite.gameObject.transform.position = new Vector3Int(location.x, location.y, 0) + currentIsland.transform.position;
    }

    #endregion

    public void ResetAirdropTimer()
    {
        StopCoroutine(airdropTimerRef);
        if (gameManager.gameOver)
            return;
        airdropTimerRef = StartCoroutine(AirdropTimer());
    }

    private IEnumerator AirdropTimer()
    {
        while (!gameManager.gameOver)
        {
            for (float i = 0; i < timerUpdateRate; i++)
            {
                yield return new WaitForSeconds(autoplaceCooldown / timerUpdateRate);
                airdropPreview.UpdateTimer((i+1)/ timerUpdateRate);
            }

            airdropPreview.nextMaterial.enabled = true;
            allyIsland.AutoPlace(airdropPreview.nextMaterial);
            //TryConstructBuilding(targetCoords);
            airdropPreview.GetNewMaterial();
        }
    }
    public void TryConstructBuilding(Vector2Int location)
    {
        if (selectingEnemy)
        {
            Debug.LogWarning("Currently on Enemy Island");
            return;
        }
        /*var building = buildingDeckManager.GetBuilding(1);
        currentIsland.PlaceObject(building, selectedCoords);
        building.Construct(this);*/
        MaterialColor matColor = currentIsland.AtGrid(location).materialData.color;
        var result = buildingChecker.CheckForBuilding(buildingDeckManager.buildingDeck, allyIsland, location, matColor);

        if (result.Item1 == null)
            return;
        foreach (var spot in result.Item1)
            allyIsland.RemoveObject(spot);
        //Get rid of this oncce implement object pooler
        Building building = Instantiate(buildingPrefab).GetComponent<Building>();
        building.buildingData = result.Item2;
        building.enabled = true;
        currentIsland.PlaceObject(building, location);
        activeBuilding = building;
        building.Construct(this);
    }
}
