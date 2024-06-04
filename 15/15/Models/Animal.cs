using System;
using System.ComponentModel;
using System.Media;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public abstract class Animal : INotifyPropertyChanged
{
    private double _x;
    private double _y;
    private int _speed;
    protected SoundPlayer SoundPlayer;
    private static Random rand = new Random();

    public double X
    {
        get => _x;
        set { _x = value; OnPropertyChanged(); }
    }

    public double Y
    {
        get => _y;
        set { _y = value; OnPropertyChanged(); }
    }

    public int Speed
    {
        get => _speed;
        set { _speed = value; OnPropertyChanged(); }
    }

    public int WalkSpeed { get; set; }
    public int RunSpeed { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public async Task MoveAsync()
    {
        await Task.Run(() =>
        {
            Speed = rand.Next(0, 2) == 0 ? WalkSpeed : RunSpeed; // Randomly choose between walk and run speed
            X = Math.Min(Math.Max(X + rand.Next(-5, 6), 0), 800);
            Y = Math.Min(Math.Max(Y + rand.Next(-5, 6), 0), 600);
			//PlaySound();
		});
    }

    protected abstract void PlaySound();
}
