using Class01.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.Model
{
    public class Messages
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string title{ get; set; }
        public string reference { get; set; }
        public Featured feature { get; set; }
    }
}
