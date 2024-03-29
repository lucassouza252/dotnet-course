﻿using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por usar nossos serviços!!");
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o Numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a Ser Depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a Ser Sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Numero da Conta de Origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Numero da Conta de Destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor da Transferencia: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceOrigem].Transferir(valorTransferencia, listContas[indiceDestino]);
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir Nova Conta!");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta, 
                saldo: entradaSaldo, 
                credito: entradaCredito, 
                nome: entradaNome
                );
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas!");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada!");
                return;
            }
            else
            {
                for(int i = 0; i < listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(conta);
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bank a seu dispor!");
            Console.WriteLine("Informe a Opção Desejada: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
