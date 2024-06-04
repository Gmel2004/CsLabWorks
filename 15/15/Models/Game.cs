using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

public class Game
{
    public ObservableCollection<Sheep> Sheeps { get; }
    public ObservableCollection<Wolf> Wolves { get; }
    public Dog Dog { get; }

    private Random _random = new Random();

    public Game()
    {
        int sheepCount = _random.Next(2, 6);
        int wolfCount = _random.Next(1, 4);

        Sheeps = new ObservableCollection<Sheep>();
        Wolves = new ObservableCollection<Wolf>();

        for (int i = 0; i < sheepCount; i++)
        {
            Sheeps.Add(new Sheep { X = _random.Next(0, 800), Y = _random.Next(0, 600) });
        }

        for (int i = 0; i < wolfCount; i++)
        {
            Wolves.Add(new Wolf { X = _random.Next(0, 800), Y = _random.Next(0, 600) });
        }

        Dog = new Dog { X = _random.Next(0, 800), Y = _random.Next(0, 600) };
    }

    public async Task GameLoop()
    {
        while (Sheeps.Count > 0 && Wolves.Count > 0)
        {
            await MoveAnimalsAsync();
            await CheckCollisionsAsync();
        }
        EndGame();
    }

    private async Task MoveAnimalsAsync()
    {
        var tasks = Sheeps.Select(async sheep =>
        {
            await sheep.MoveAsync();
            await Task.Delay(50); // Wait for the speed delay
        })
                          .Concat(Wolves.Select(async wolf =>
                          {
                              await wolf.MoveAsync();
                              await Task.Delay(50); // Wait for the speed delay
                          }))
                          .Concat(new Task[] {
                              Dog.MoveAsync().ContinueWith(async _ =>
                              {
                                  await Task.Delay(50); // Wait for the speed delay
                              })
                          });

        await Task.WhenAll(tasks);
    }

    private async Task CheckCollisionsAsync()
    {
        await Task.Run(() => 
        {
            var animals = Sheeps.Cast<Animal>().Concat(Wolves).Concat(new[] { Dog }).ToList();
            for (int i = 0; i < animals.Count; i++)
            {
                for (int j = i + 1; j < animals.Count; j++)
                {
                    if (IsColliding(animals[i], animals[j]))
                    {
                        HandleCollision(animals[i], animals[j]);
                    }
                }
            }
        });
    }

    private bool IsColliding(Animal animal1, Animal animal2)
    {
        return Math.Abs(animal1.X - animal2.X) < 50 && Math.Abs(animal1.Y - animal2.Y) < 50;
    }

    private void HandleCollision(Animal animal1, Animal animal2)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            if (animal1 is Sheep && animal2 is Sheep)
            {
                Sheeps.Add(new Sheep { X = _random.Next(0, 800), Y = _random.Next(0, 600) });
            }
            else if (animal1 is Sheep && animal2 is Wolf || animal1 is Wolf && animal2 is Sheep)
            {
                var sheep = animal1 is Sheep ? animal1 : animal2;
                Sheeps.Remove((Sheep)sheep);
            }
            else if (animal1 is Wolf && animal2 is Dog || animal1 is Dog && animal2 is Wolf)
            {
                var wolf = animal1 is Wolf ? animal1 : animal2;
                Wolves.Remove((Wolf)wolf);
            }
            else if (animal1 is Wolf && animal2 is Wolf)
            {
                Wolves.Add(new Wolf { X = _random.Next(0, 800), Y = _random.Next(0, 600) });
            }
        });
    }

    private void EndGame()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            MessageBox.Show("Игра завершена!");
            Application.Current.Shutdown();
        });
    }
}
