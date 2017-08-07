using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase
{
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        private new const string Message = "Song seconds should be between 0 and 59.";
        public InvalidSongSecondsException()
            :base(Message)
        {
        }
        public InvalidSongSecondsException(string message) 
            : base(message)
        {
        }
    }
}
