using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

public class ViewModel
{
    private Game _game;

    public ObservableCollection<Sheep> Sheeps => _game.Sheeps;
    public ObservableCollection<Wolf> Wolves => _game.Wolves;
    public Dog Dog => _game.Dog;
    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModel()
    {
        _game = new Game();
        Task.Run(_game.GameLoop);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
