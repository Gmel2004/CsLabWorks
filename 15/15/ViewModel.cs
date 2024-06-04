using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

public class ViewModel
{
    private Game game;

    public ObservableCollection<Sheep> Sheeps => game.Sheeps;
    public ObservableCollection<Wolf> Wolves => game.Wolves;
    public Dog Dog => game.Dog;
    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModel()
    {
        game = new Game();
        Task.Run(game.GameLoop);
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
