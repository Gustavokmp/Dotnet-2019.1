using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade1.model
{
    class Consulta
    {
        public String Procedimento { get; set; }
        public Paciente Paciente { get; set; }

        public Consulta(Paciente paciente, String procedimento)
        {
            Paciente = paciente;
            Procedimento = procedimento;
        }


    }
}
