using CommunityToolkit.Mvvm.ComponentModel;

namespace LothlorienGUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // Nombre de plantes (0 pour l'instant, sera dynamique plus tard)
    public int PlantCount => 0;

    // L'attribut [ObservableProperty] génère automatiquement IsCardView 
    // et gère la notification de changement (INotifyPropertyChanged)
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsListView))] // Notifie IsListView quand IsCardView change
    private bool _isCardView = true;

    public bool IsListView => !IsCardView;
}