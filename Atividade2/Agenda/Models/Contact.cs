
using System.ComponentModel.DataAnnotations;


namespace Agenda.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite seu nome"), MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o telefone"), MaxLength(14)]
        public string Phone { get; set; }
    }
}