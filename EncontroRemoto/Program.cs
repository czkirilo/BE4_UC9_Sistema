using System;
using System.Threading;
using System.Collections.Generic;

namespace EncontroRemoto
{
  class Program
  {
    static void Main(string[] args)
    {
      List<PessoaFisica> listaPf = new List<PessoaFisica>();


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
============================================
|       Escolha uma das opções abaixo       |
--------------------------------------------
|               PESSOA FÍSICA               |
|         1 - Cadatrar Pessoa Física        |
|         2 - Listar Pessoa Física          |
|         3- Remover Pessoa Física          |
|                                           |
|               PESSOA JURÍDICA             |
|         4 - Cadatrar Pessoa Juridica      |
|         5 - Listar Pessoa Juridica        |
|         6- Remover Pessoa Juridica        |
|                                           |
|           0 - Sair                        |
============================================
");

        opcao = Console.ReadLine();

        switch (opcao)
        {
          case "1":
            Endereco endPf = new Endereco();

            // Console.WriteLine($"Digite seu logradouro");
            // endPf.logradouro = Console.ReadLine();

            // Console.WriteLine($"Digite o Numero");
            // endPf.numero = int.Parse(Console.ReadLine());

            // Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
            // endPf.complemento = Console.ReadLine();

            // Console.WriteLine($"Este endereço é comercial? S/N");
            // string endComercial = Console.ReadLine().ToUpper();

            // if (endComercial == "S")
            // {
            //   endPf.enderecoComercial = true;
            // }
            // else
            // {
            //   endPf.enderecoComercial = false;
            // }


            PessoaFisica novapf = new PessoaFisica();

            novapf.endereco = endPf;

            // Console.WriteLine($"Digite seu CPF (somente numeros)");
            // novapf.cpf = Console.ReadLine();

            Console.WriteLine($"Digite seu nome");
            novapf.nome = Console.ReadLine();

            // Console.WriteLine($"Digite seu rendimento mensal");
            // novapf.rendimento = float.Parse(Console.ReadLine());

            // Console.WriteLine($"Digite sua data de nascimento (ano, mês, dia)");
            // novapf.dataNascimento = DateTime.Parse(Console.ReadLine());

            PessoaFisica pf = new PessoaFisica();
            // pf.ValidarDataNascimento(pf.dataNascimento);

            bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);
            Console.WriteLine(idadeValida);

            if (idadeValida == true)
            {
              Console.WriteLine($"Cadastro Aprovado");
              listaPf.Add(novapf);
              Console.WriteLine(novapf.PagarImposto(novapf.rendimento));

            }
            else
            {
              Console.WriteLine($"Cadastro Não Aprovado");
            }

            // Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));
            // Console.WriteLine("Rua:" + novapf.endereco.logradouro + ", " + novapf.endereco.numero);


            using (StreamWriter sw = new StreamWriter($"{novapf.nome}.txt"))
            {
              sw.Write($"{novapf.nome}");
            }

            break;

          case "2":
            // foreach (var cadaItem in listaPf)
            // {
            //   Console.WriteLine($"{cadaItem.nome}, {cadaItem.cpf}, {cadaItem.endereco.logradouro}");
            // }
            using (StreamReader sr = new StreamReader("caique.txt"))
            {
              string linha;
              while ((linha = sr.ReadLine()) != null)
              {
                Console.WriteLine($"{linha}");
              }
            }
            Console.WriteLine($"Aperte Enter para continuar");
            Console.ReadLine();




            break;
          case "3":
            Console.WriteLine($"Digite o CPF que deseja remover");
            string cpfProcurado = Console.ReadLine();

            PessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);

            if (pessoaEncontrada != null)
            {
              listaPf.Remove(pessoaEncontrada);
              Console.WriteLine($"Cadastro Removido");
            }
            else
            {
              Console.WriteLine($"CPF não encontrado");
            }
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
