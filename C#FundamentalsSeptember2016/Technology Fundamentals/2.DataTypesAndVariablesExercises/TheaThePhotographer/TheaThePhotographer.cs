using System;

namespace TheaThePhotographer
{
    public class TheaThePhotographer
    {
        public static void Main(string[] args)
        {
            int numOfPictures = int.Parse(Console.ReadLine());
            int filtredTime = int.Parse(Console.ReadLine());
            int percentOfGoodPic = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            long calculateGoodPic = (long)Math.Ceiling((double)(numOfPictures * percentOfGoodPic) / 100); // 1000 * 50 = 50000 / 100 = 500
            long calculateTotalPic = (long)numOfPictures * filtredTime; // 1000 * 1 = 1000 TRQBVA DA KASTNEM KYM LONG , ZASHTOTO (*) E OPERATOR KOITO UMNOJAVA SAMO INT I VRYSHTA INT
            long calculateGoodPicUpload = calculateGoodPic * uploadTime; // 500 * 1 = 500
            long totalTime = calculateTotalPic + calculateGoodPicUpload; // 1000 + 500 = 1500

            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            string result = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(result);


        }
    }
}
