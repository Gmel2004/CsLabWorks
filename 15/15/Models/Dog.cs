using System;
using System.IO;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Dog : Animal
{
    public Uri ImagePath => new Uri("C:\\Users\\Gleb\\Desktop\\Programming\\Study\\CsLabWorks\\15\\15\\Images\\dog.png", UriKind.Relative);
    public BitmapImage ImageSource => new BitmapImage(ImagePath);
    public Dog()
    {
        SoundPlayer = new SoundPlayer($"../../Sounds/dog.wav");
        WalkSpeed = 450;
        RunSpeed = 100;
    }

    protected override void PlaySound()
    {
        SoundPlayer.Play();
    }
}
