using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase
{
    public static class Validator
    {
        public static string ValidateArtist(string artist)
        {
            if (artist.Length < 3 || artist.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            return artist;
        }
        public static string ValidateSong(string song)
        {
            if (song.Length < 3 || song.Length > 20)
            {
                throw new InvalidSongNameException();
            }

            return song;
        }
        public static string ValidateDuration(string duration)
        {

            int[] songParse = duration.Split(new char[] { ':' }).Select(int.Parse).ToArray();
            int minutes = songParse[0];
            int seconds = songParse[1];
            if (minutes > 14 || minutes < 0)
            {
                throw new InvalidSongMinutesException();
            }
            if (seconds > 59 || seconds < 0)
            {
                throw new InvalidSongSecondsException();
            }
            
            return duration;
        }
    }
}
