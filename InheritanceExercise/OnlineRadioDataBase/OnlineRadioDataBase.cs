//Create an online radio station database.It should keep information about all added songs.On the first line you are going 
//to get the number of songs you are going to try adding.On the next lines you will get the songs to be added in the format 
// <artist name>;<song name>;<minutes:seconds>. To be valid, every song should have an artist name, a song name and length.
//Design a custom exception hierarchy for invalid songs: 
//InvalidSongException
//InvalidArtistNameException
//InvalidSongNameException
//InvalidSongLengthException
//InvalidSongMinutesException
//InvalidSongSecondsException
//Validation
//Artist name should be between 3 and 20 symbols.
//Song name should be between 3 and 30 symbols.
//Song length should be between 0 second and 14 minutes and 59 seconds.
//Song minutes should be between 0 and 14.
//Song seconds should be between 0 and 59.

namespace OnlineRadioDataBase
{
    using Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class OnlineRadioDataBase
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();

            int numberOfSongs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] parameters = Console.ReadLine().Split(';');
                string artistName = parameters[0];
                string songName = parameters[1];
                

                try
                {
                    int[] lengthOtTheSong = parameters[2].Split(':').Select(int.Parse).ToArray();
                    Song song = new Song(artistName, songName, lengthOtTheSong[0], lengthOtTheSong[1]);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                   
                }
                catch (InvalidSongException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid song length.");
                }

            }
            Console.WriteLine($"Song added: {playlist.Count}");

            int totalMinutes = playlist.Sum(x => x.Minutes);
            int totalSeconds = playlist.Sum(x => x.Seconds);

            totalSeconds += totalMinutes * 60;

            int finalMinutes = totalSeconds / 60;
            int finalSeconds = totalSeconds % 60;
            int finalHours = finalMinutes / 60;
            finalMinutes %= 60;
            Console.WriteLine($"Playlist length: {finalHours}h {finalMinutes}m {finalSeconds}s");
        }
    }

    public class Song
    {
        private int seconds;
        private int minutes;
        private string artistName;
        private string songName;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }

            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public string ArtistName
        {
            get
            {
                return this.artistName;
            }

            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                artistName = value;
            }
        }

        public string SongName
        {
            get
            {
                return this.songName;
            }

            set
            {
                if (value.Length < 3 || value.Length >30)
                {
                    throw new InvalidSongNameException();
                }

                songName = value;
            }
        }
    }
}
