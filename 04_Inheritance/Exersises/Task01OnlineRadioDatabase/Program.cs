using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
    {
        static void Main(string[] args)
        {

        var songsNumber = int.Parse(Console.ReadLine());

        List<Song> songdata = new List<Song>();


        for (int i = 0; i < songsNumber; i++)
        {
            var cmdArgs = Console.ReadLine().Split(';');

            TimeSpan time;

            if (cmdArgs.Length!=3)
            {
                Console.WriteLine(new ArgumentException(ExceptionMessages.InvalidSongException));
                continue;
            }
            try
            {
                var minutes = int.Parse(cmdArgs[2].Split(':').First());
                var seconds = int.Parse(cmdArgs[2].Split(':').Last());

                if (minutes<0||minutes>14)
                {
                    Console.WriteLine(ExceptionMessages.InvalidSongMinutesException);
                    continue;
                }
                if (seconds < 0 || seconds > 59)
                {
                    Console.WriteLine(ExceptionMessages.InvalidSongSecondsException);
                    continue;
                }

                time = new TimeSpan(0,minutes,seconds);
            }
            catch (Exception)
            {
               Console.WriteLine(ExceptionMessages.InvalidSongLengthException);
                continue;
            }

            var artistname = cmdArgs[0];
            var songName = cmdArgs[1];
            try
            {
                Song currentSong = new Song(artistname, songName, time);
                songdata.Add(currentSong);
                Console.WriteLine("Song added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        TimeSpan sum = CalculateAlllength(songdata);

        Console.WriteLine($"Songs added: {songdata.Count}");
        Console.WriteLine($"Playlist length: {sum.Hours}h {sum.Minutes}m {sum.Seconds}s");
    }

    private static TimeSpan CalculateAlllength(List<Song> songdata)
    {
        TimeSpan sum = new TimeSpan();

        foreach (var item in songdata)
        {
            sum += item.SongLength;
        }

        return sum;
    }
}

