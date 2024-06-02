using System;
using System.Media;
using System.Windows.Media.Imaging;

public class Wolf : Animal
{
    public Uri ImagePath => new Uri("../../Images/wolf.png", UriKind.Relative);
    public BitmapImage ImageSource => new BitmapImage(ImagePath);
    public Wolf()
    {
        SoundPlayer = new SoundPlayer("../../Sounds/wolf.wav");
        WalkSpeed = 400;
        RunSpeed = 150;
    }

    protected override void PlaySound()
    {
        SoundPlayer.Play();
    }
}
