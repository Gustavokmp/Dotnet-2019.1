using Atividade1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade1.repository
{
    class Database
    {

        public List<Paciente> Pacientes = new List<Paciente>();

        public List<Consulta> Consultas = new List<Consulta>();

        public void addPaciente(Paciente paciente)
        {
            this.Pacientes.Add(paciente);
        }

        public String findPacienteByName(String nome)
        {
            Paciente paciente = null;


            Pacientes.ForEach((Paciente obj) =>
            {
                if (obj.Nome.Equals(nome))
                {
                    paciente = obj;

                }
            });

            return "Nome:"+paciente.Nome+" CPF:"+paciente.CPF;

        }

        public Paciente findPacienteByCPF(String cpf)
        {
            Paciente paciente = null;


            Pacientes.ForEach((Paciente obj) =>
            {
                if (obj.CPF.Equals(cpf))
                {
                    paciente = obj;

                }
            });

            return paciente;

        }

        public Consulta findConsultaByPaciente(Paciente paciente)
        {
            Consulta consulta = null;
            Consultas.ForEach((Consulta obj) =>
            {
                if (obj.Paciente.Equals(paciente))
                {
                    consulta = obj;
                }
            });
            return consulta;
        }
    }

}
