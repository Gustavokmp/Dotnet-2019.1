using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade1.model
{
    class Paciente
    {
        public String Nome { get; set; }
        public String CPF { get; set; }

        public Paciente(String nome, String cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
