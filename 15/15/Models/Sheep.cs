using System;
using System.Media;
using System.Windows.Media.Imaging;

public class Sheep : Animal
{
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
