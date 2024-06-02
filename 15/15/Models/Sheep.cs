using System;
using System.Media;
using System.Windows.Media.Imaging;

public class Sheep : Animal
{
    public Uri ImagePath => new Uri("C:\\Users\\Gleb\\Desktop\\Programming\\Study\\CsLabWorks\\15\\15\\Images\\sheep.png", UriKind.Relative);
    public BitmapImage ImageSource => new BitmapImage(ImagePath);
    public Sheep()
    {
        SoundPlayer = new SoundPlayer("../../Sounds/sheep.wav");
        WalkSpeed = 500;
        RunSpeed = 200;
    }

    protected override void PlaySound()
    {
        SoundPlayer.Play();
    }
}
