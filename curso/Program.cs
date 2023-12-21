using System;
using cursoEFCore.Domain;
using cursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace cursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //InserirDados();
            InserirDadosEmMassa();
        }

        public static void InserirDadosEmMassa(){

            var produto = new Produto
            {
                Descricao = "Produto Teste em Massa",
                CodigoBarras = "1234567891232",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente 
            {
                Nome = "Amarildo Ferreira",
                Telefone = "930549221",
                Cep = "99990012",
                Estado = "SE",
                Cidade = "Luanda",
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(produto,cliente);
            var registos = db.SaveChanges();
            Console.WriteLine($"Total de registos: {registos}");
        }

        public static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            //db.Add(produto);

            var registos = db.SaveChanges();
            Console.WriteLine($"Total de registos: {registos}");

        }
        public static void ConsultarDados(){

            using var db = new Data.ApplicationContext();
            //var consultaPorSintaxe = (from c in db.Clientes where c.Id>0 select c).ToList();
        }
    }
}
