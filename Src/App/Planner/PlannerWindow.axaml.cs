namespace Isitar.RoomPlanner.App.Planner;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Logic.Models;

public partial class PlannerWindow : Window
{
    private readonly PlannerVm vm;

    public PlannerWindow()
    {
        InitializeComponent();
        var fakePlan = new Plan("Unnamed Plan");
        fakePlan.Furnitures.Add(new Furniture("Furniture 1", 10, 20,  "red"));
        fakePlan.Furnitures.Add(new Furniture("Furniture 2", 40, 50,  "green"));
        vm = new PlannerVm(fakePlan);
    }
    public PlannerWindow(PlannerVm vm) : this()
    {
        this.vm = vm;
        DataContext = vm;

#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}