using UnityEngine;

public class EndState : MonoBehaviour
{
    public bool Ended = false;
    public bool Die = false;
    public bool Music = true;


    public AudioSource MusicInGame;
    public AudioSource MusicDefeat;
    public AudioSource MusicWin;

    private void Awake()
    {
        MusicInGame.Play();

    }

    private void FixedUpdate()
    {
        

        if (Ended == true)
        {
            MusicInGame.Stop();
            MusicWin.Stop();
            MusicDefeat.Play();

            Ended = false;
        }

        if (Die == true)
        {
            MusicInGame.Stop();
            MusicDefeat.Stop();
            MusicWin.Play();

            Die = false;
        }
    }

}
