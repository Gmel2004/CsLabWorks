using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class Dog : Animal
{
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
