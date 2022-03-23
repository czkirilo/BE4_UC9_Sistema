using System;
using System.Threading;
using System.Collections.Generic;

namespace EncontroRemoto
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
=============================================
|    Bem vindo ao sistema de cadastro       |
|    de pessoa física e pessoa jurídica     |
=============================================
");
            BarraCarregamento("Iniciando");

            string? opcao;

            do
            {
                Console.WriteLine(@$"
=====================================
|   Escolha uma das opções abaixo   |
|        1 - Pessoa Física          |
|        2 - Pessoa jurídica        |
|                                   |
|        0- Sair                    |
=====================================
");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Endereco endPf = new Endereco();

                        endPf.logradouro = "Rua X";
                        endPf.numero = 100;
                        endPf.complemento = "Próximo ao Senai";
                        endPf.enderecoComercial = false;

                        PessoaFisica novapf = new PessoaFisica();

                        novapf.endereco = endPf;
                        novapf.cpf = "123456789";
                        novapf.rendimento = 1200;
                        novapf.dataNascimento = new DateTime(2000, 02, 20);
                        novapf.nome = "Jessica";

                        PessoaFisica pf = new PessoaFisica();
                        // pf.ValidarDataNascimento(pf.dataNascimento);

                        bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);
                        Console.WriteLine(idadeValida);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado");

                        }
                        else
                        {
                            Console.WriteLine($"Cadastro Não Aprovado");
                        }

                        // Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
                        // Console.WriteLine("Rua:" + novapf.endereco.logradouro + ", " + novapf.endereco.numero);
                        break;

                    case "2":

                        PessoaJuridica pj = new PessoaJuridica();

                        PessoaJuridica novapj = new PessoaJuridica();

                        Endereco endPj = new Endereco();

                        endPj.logradouro = "Rua X";
                        endPj.numero = 100;
                        endPj.complemento = "Próximo ao Senai";
                        endPj.enderecoComercial = true;

                        novapj.endereco = endPj;
                        novapj.cnpj = "12345678900001";
                        novapj.rendimento = 8000;
                        novapj.razaoSocial = "Pessoa Juridica";

                        break;

                    case "0":
                        Console.WriteLine($"Obrigado por utilizar o nosso sistma");
                        BarraCarregamento("Finalizando");
                        break;

                    default:
                        Console.WriteLine($"Opção inválida, digite uma opção válida");

                        break;
                }
            } while (opcao != "0");
        }

        static void BarraCarregamento(string textoCarregamento)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);


            for (var contador = 0; contador < 10; contador++)
            {

                Console.Write($".");
                Thread.Sleep(500);
            }
            Console.ResetColor();


        }
    }
}
