using System;
using System.Collections.Generic;
using System.Text;


  public  class Song
    {

    private string artistName;

    private string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length<3||value.Length>20)
            {
                throw new ArgumentException(ExceptionMessages.InvalidArtistNameException);
            }
            artistName = value;
        }
    }

    private string songName;

    private string SongName
    {
        get { return songName; }
        set
        {

            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException(ExceptionMessages.InvalidSongNameException);
            }
            songName = value;
        }
    }

    private TimeSpan songLength;

    public TimeSpan SongLength
    {
        get { return songLength; }
       private set
        {
            if (value.Minutes<0 ||value.Minutes>14)
            {
                throw new ArgumentException(ExceptionMessages.InvalidSongMinutesException);
            }
            if (value.Seconds < 0 || value.Seconds > 59)
            {
                throw new ArgumentException(ExceptionMessages.InvalidSongSecondsException);
            }
            songLength = value;
        }
    }

    public Song(string artistName, string songName, TimeSpan length)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.SongLength = length;
    }



}

