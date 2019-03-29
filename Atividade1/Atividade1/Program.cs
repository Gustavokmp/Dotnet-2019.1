using Atividade1.model;
using Atividade1.repository;
using System;

namespace Atividade1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database repository = new Database();
            while (true)
            { 
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1- Cadastrar paciente");
                Console.WriteLine("2- Pesquisar paciente");
                Console.WriteLine("3- Cadastrar atendimento");
                Console.WriteLine("4- Realizar atendimento");
                Console.WriteLine("9- Finalizar");
                int escolha = int.Parse(Console.ReadLine());
                if (escolha == 9) break;
                switch (escolha)
                {
                    case 1:
                        {
                            Console.WriteLine("Digite o nome");
                            String nome = Console.ReadLine();
                            Console.WriteLine("Digite o cpf");
                            String cpf_pesquisa = Console.ReadLine();
                            Paciente pacienteAux = new Paciente(nome, cpf_pesquisa);
                            repository.addPaciente(pacienteAux);
                            Console.Clear();

                            break;
                        }


                    case 2:
                        {
                            Console.WriteLine("Digite o nome");
                            String nome = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine(repository.findPacienteByName(nome));
                            break;

                        }
                    case 3:
                        {

                            Console.WriteLine("Digite o cpf do paciente");
                            String cpf_pesquisar = Console.ReadLine();
                            Paciente pacienteAux = repository.findPacienteByCPF(cpf_pesquisar);
                            Console.WriteLine("Digite o nome do procedimento");
                            String proc = Console.ReadLine();
                            repository.Consultas.Add(new Consulta(pacienteAux, proc));
                            Console.Clear();


                            break;

                        }
                    case 4:
                        Console.WriteLine("Digite o cpf do paciente");
                        String cpf = Console.ReadLine();
                        Paciente paciente = repository.findPacienteByCPF(cpf);
                        Consulta consulta = repository.findConsultaByPaciente(paciente);
                        Console.WriteLine("Paciente: " + paciente.Nome);
                        Console.WriteLine("Encaminhado para o procedimento: " + consulta.Procedimento);



                        break;


                }
            }
        }
    }
}
