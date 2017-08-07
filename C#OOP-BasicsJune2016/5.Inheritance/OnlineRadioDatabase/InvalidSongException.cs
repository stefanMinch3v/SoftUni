using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase
{
    class InvalidSongException : Exception
    {
        private new const string Message = "Invalid song."; // can be used keyword "new" right before const to exclude the underlined message

        public InvalidSongException()
            : base(Message)
        {
        }

        public InvalidSongException(string message)
            : base(message)
        {
        }
    }
}
