using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Class01.VeiwModel
{
    public class VisitorViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "input Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "input Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "input Email")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "input Password")]
        public string Password { get; set; }
    }
}
