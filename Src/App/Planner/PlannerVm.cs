namespace Isitar.RoomPlanner.App.Planner;

using Isitar.RoomPlanner.Logic.Models;

public class PlannerVm
{
    public Plan Plan { get; }

    public PlannerVm(Plan plan)
    {
        Plan = plan;
    }
}