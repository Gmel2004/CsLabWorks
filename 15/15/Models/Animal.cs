using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public abstract class Animal : INotifyPropertyChanged
{
    private double x;
    private double y;

    private static Random rnd = new Random();

    public double X
    {
        get => x;
        set
        {
            x = Math.Min(Math.Max(value, 0), 800);
            OnPropertyChanged();
        }
    }

    public double Y
    {
        get => y;
        set
        {
            y = Math.Min(Math.Max(value, 0), 600);
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public Animal()
    {
        X = rnd.Next(0, 800);
        Y = rnd.Next(0, 600);
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public async Task MoveAsync()
    {
        await Task.Run(() =>
        {
            X += rnd.Next(-5, 6);
            Y += rnd.Next(-5, 6);
        });
    }

    public bool IsCollidingTo(Animal animal) =>
        Math.Abs(X - animal.X) < 50 && Math.Abs(Y - animal.Y) < 50;
}
