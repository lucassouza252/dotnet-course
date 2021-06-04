using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao  = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch(opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = ObterOpcaoUsuario();
            }

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar uma Série");
            Console.WriteLine("Digite o Id da Série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(entradaId);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir uma Série");
            Console.WriteLine("Digite o Id da Série: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exclui(entradaId);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série: ");
            int entradaId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero Entre as Opcoes Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descricao da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: entradaId,
                genero: (Genero) entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
            
            repositorio.Atualiza(entradaId, atualizaSerie);     
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero Entre as Opcoes Acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descricao da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero) entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
            
            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Lista Vazia");
                return;
            }
            else
            {
                foreach(var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "- Excluido" : ""));
                    
                }
            }
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Séries a Seu Dispor");
            Console.WriteLine("Informe a Opção Desejada: ");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
