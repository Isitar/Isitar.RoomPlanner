namespace Isitar.RoomPlanner.App;

using Avalonia.Controls;
using Logic.Models;
using Planner;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        BtnNewPlan.Click += (sender, args) =>
        {
            var plan = new Plan("New Plan");
            plan.Furnitures.Add(new Furniture("Schrank", 1.25, 0.8, "red"));
            plan.Furnitures.Add(new Furniture("Bett", 2, 2.2, "red"));
            plan.Furnitures.Add(new Furniture("Pult", 1.25, 0.8, "red"));
            var planner = new PlannerWindow(new PlannerVm(plan));
            planner.Closed += (sender, args) => { Show(); };
            planner.Show();
            Hide();
        };
    }
}