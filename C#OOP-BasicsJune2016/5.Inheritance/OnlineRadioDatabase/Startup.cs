using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineRadioDatabase
{
    public class Startup
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            string pattern = @"^([a-zA-Z0-9\s]+)\;([a-zA-Z0-9\s]+)\;([0-9:]+)$";
            int counterSongs = 0;
            List<string> saveDuration = new List<string>();

            for (int i = 0; i < numberOfRows; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid song length.");
                    return;
                }
                try
                {
                    string artist = Validator.ValidateArtist(match.Groups[1].ToString());
                    string song = Validator.ValidateSong(match.Groups[2].ToString());
                    string duration = Validator.ValidateDuration(match.Groups[3].ToString());
                    saveDuration.Add(duration);
                    counterSongs++;
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ise)
                {
                    Console.WriteLine(ise.Message);
                }     
            }
            Console.WriteLine($"Songs added: {counterSongs}");
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            CountAllSongs(hours, minutes, seconds, saveDuration);
        }

        private static void CountAllSongs(int hours, int minutes, int seconds, List<string> saveDuration)
        {

            foreach (var duration in saveDuration)
            {
                int[] takeAll = duration.Split(new char[] { ':' }).Select(int.Parse).ToArray();
                minutes += takeAll[0];
                seconds += takeAll[1];
                while (seconds > 59)
                {
                    minutes++;
                    seconds -= 60;
                }
                while (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }

            }

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }
}
