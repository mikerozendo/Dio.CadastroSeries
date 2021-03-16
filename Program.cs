using System;
using System.Globalization;
using System.Collections.Generic;
using Dio.CadastroSeries.Entities;
using Dio.CadastroSeries.Entities.Enums;
using System.Text;

namespace Dio.CadastroSeries
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Menu());

            int decisaoUsuario = int.Parse(Console.ReadLine());

            while (decisaoUsuario != 6)
            {
                switch (decisaoUsuario)
                {
                    case 1:
                        Console.Write("Informe o título do filme: ");
                        string tituloFilme = Console.ReadLine();

                        Console.Write("Informe o gênero do filme: ");
                        string generoFilme = Console.ReadLine();
                        Genero genero;
                        Enum.TryParse(generoFilme, out genero);

                        Console.Write("Informe um número de cadastro: ");
                        int idFilme = int.Parse(Console.ReadLine());

                        Console.Write("Informe o ano de lançamento (dd/MM/yyy): ");
                        DateTime anoLancamento = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Console.Write("Informe o tempo de duração (HH:mm:ss): ");
                        TimeSpan duracaoFilme = TimeSpan.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Filme novoCadastroFilme = new Filme(genero, tituloFilme, idFilme, anoLancamento, duracaoFilme);
                        Adicionar(novoCadastroFilme);

                        Console.WriteLine(Menu());
                        decisaoUsuario = int.Parse(Console.ReadLine());

                        break;


                    case 2:
                        Console.Write("Informe o nome da série: ");
                        string tituloSerie = Console.ReadLine();

                        Console.Write("Informe o gênero da série: ");
                        string generoSerie = Console.ReadLine();
                        Genero generoS;
                        Enum.TryParse(generoSerie, out generoS);

                        Console.Write("Informe um número de cadastro: ");
                        int idSerie = int.Parse(Console.ReadLine());

                        Console.Write("Informe o ano de lançamento (dd/MM/yyy): ");
                        DateTime anoLancamentoSerie = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Console.Write("Informe o número de temporadas: ");
                        int quantidadeTemporadas = int.Parse(Console.ReadLine());

                        Console.Write("Serie finalizada ou em andamento? (Produzindo / Finalizada): ");
                        string verificacaoProducao = Console.ReadLine();
                        StatusProducaoSeries status;
                        Enum.TryParse(verificacaoProducao, out status);

                        if (verificacaoProducao == "Produzindo")
                        {
                            Console.Write("Informe a data de lançamento da próxima temporada (dd/MM/yyyy): ");
                            DateTime lancamento = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Serie novoCadastroSerie = new Serie(generoS, tituloSerie, anoLancamentoSerie, idSerie,
                                quantidadeTemporadas, status, lancamento);
                            Adicionar(novoCadastroSerie);
                        }
                        else if (verificacaoProducao == "Finalizada")
                        {
                            Console.Write("Informe a data em que foi lançada a ultima temporada (dd/MM/yyyy): ");
                            DateTime lancamento = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Serie novoCadastroSerie = new Serie(generoS, tituloSerie, anoLancamentoSerie, idSerie,
                                quantidadeTemporadas, status, lancamento);
                            Adicionar(novoCadastroSerie);
                        }

                        Console.WriteLine(Menu());
                        decisaoUsuario = int.Parse(Console.ReadLine());
                        break;


                    case 3:

                        Console.Write("Informe o id do titulo: ");
                        int idRemover = int.Parse(Console.ReadLine());
                        Remover(idRemover);

                        Console.WriteLine(Menu());
                        decisaoUsuario = int.Parse(Console.ReadLine());

                        break;

                    case 4:
                        Console.WriteLine("===========================================================================");
                        Console.WriteLine("                             LISTA DE CADASTROS                            ");
                        Console.WriteLine("===========================================================================");
                        ConsultaLista();

                        Console.WriteLine(Menu());
                        decisaoUsuario = int.Parse(Console.ReadLine());

                        break;

                    case 5:
                        Console.Clear();

                        Console.WriteLine(Menu());
                        decisaoUsuario = int.Parse(Console.ReadLine());

                        break;


                }
            }
        }

        public static string Menu()
        {
            StringBuilder menu = new StringBuilder();

            menu.AppendLine("===========================================================================");
            menu.AppendLine("                           MENU DO ADMINISTRADOR                           ");
            menu.AppendLine("===========================================================================");
            menu.AppendLine();
            menu.AppendLine("Digite o número da opção desejada");
            menu.AppendLine();
            menu.AppendLine("1) Adicionar novo filme ao cadastro");
            menu.AppendLine("2) Adicionar nova série ao cadastro");
            menu.AppendLine("3) Remover titulo do cadastro");
            menu.AppendLine("4) Consultar lista titulos");
            menu.AppendLine("5) Limpar tela");
            menu.AppendLine("6) Encerrar sessão");
            return menu.ToString();
        }

        static List<BaseCadastro> listaCadastro = new List<BaseCadastro>();

        public static void Adicionar(BaseCadastro obj)
        {
            listaCadastro.Add(obj);
        }

        public static void Remover(int id)
        {
            foreach (BaseCadastro obj in listaCadastro)
            {
                if (obj.Id == id)
                {
                    listaCadastro.Remove(obj);
                }

            }
        }

        public static void ConsultaLista()
        {
            foreach (BaseCadastro obj in listaCadastro)
            {
                Console.WriteLine(obj.ConsultarDados().ToString());
            }
        }
    }
}
