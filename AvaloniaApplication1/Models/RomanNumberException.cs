using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaApplication1.Models
{
    public class RomanNumberException : Exception 
    {
        public RomanNumberException(string aMessage)
            : base(aMessage) { }
    }
}
