using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "BuildingAction/AttackEnemyAction")]
public class AttackEnemyAction : BuildingAction//TimedBuildingAction
{
    public override void PerformAction(IslandController controller, Building building)
    {
        controller.SwitchState(controller.attackState);
        //controller.StartTimedAction(actionTime, TimeOutAction);
    }

    /*public override void TimeOutAction(IslandController controller)
    {
        controller.SwitchState(controller.placeMaterialState);
    }*/
}

