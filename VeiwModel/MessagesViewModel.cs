using Class01.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.VeiwModel
{
    public class MessagesViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public string title { get; set; }

        public string reference { get; set; }

        [Required]
        public Featured feature { get; set; }
    }
}
