using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

public class Game
{
    private const int millisecondsDelay = 50;
    public ObservableCollection<Sheep> Sheeps { get; }
    public ObservableCollection<Wolf> Wolves { get; }
    public Dog Dog { get; }

    private Random rnd = new Random();

    public Game()
    {
        Sheeps = new ObservableCollection<Sheep>(
            Enumerable.Range(0, rnd.Next(2, 6)).Select(t => new Sheep()));
        Wolves = new ObservableCollection<Wolf>(
            Enumerable.Range(0, rnd.Next(1, 4)).Select(t => new Wolf()));
        Dog = new Dog();
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
            await Task.Delay(millisecondsDelay);
        })
                          .Concat(Wolves.Select(async wolf =>
                          {
                              await wolf.MoveAsync();
                              await Task.Delay(millisecondsDelay);
                          }))
                          .Concat(new Task[] {
                              Dog.MoveAsync().ContinueWith(async _ =>
                              {
                                  await Task.Delay(millisecondsDelay);
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
                    if (animals[i].IsCollidingTo(animals[j]))
                    {
                        HandleCollision(animals[i], animals[j]);
                    }
                }
            }
        });
    }

    private void HandleCollision(Animal animal1, Animal animal2)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            if (animal1 is Sheep && animal2 is Sheep)
            {
                Sheeps.Add(new Sheep());
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
                Wolves.Add(new Wolf());
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
