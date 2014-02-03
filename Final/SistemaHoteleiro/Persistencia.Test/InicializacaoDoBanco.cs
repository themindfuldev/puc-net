using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Modelo.Dominio;
using Persistencia.ORM;

namespace Persistencia.Test
{
    [TestFixture]
    public class InicializacaoDoBanco
    {
        [Test]
        public void GerarBanco()
        {
            var cfg = new Configuration();
            cfg.Configure();
           
            new SchemaExport(cfg).Execute(true, true, false);
        }

        [Test]
        public void InserirDadosIniciais()
        {
            // Categorias de quarto
            var categoriaDeQuartoEconomico = new CategoriaDeQuarto {Nome = "Econômico", ValorDaDiaria = 80};
            DAO.Save(categoriaDeQuartoEconomico);

            var categoriaDeQuartoSimples = new CategoriaDeQuarto { Nome = "Simples", ValorDaDiaria = 100 };
            DAO.Save(categoriaDeQuartoSimples);

            var categoriaDeQuartoDuplo = new CategoriaDeQuarto { Nome = "Duplo", ValorDaDiaria = 140 };
            DAO.Save(categoriaDeQuartoDuplo);

            var categoriaDeQuartoTriplo = new CategoriaDeQuarto { Nome = "Triplo", ValorDaDiaria = 180 };
            DAO.Save(categoriaDeQuartoTriplo);

            var categoriaDeQuartoPresidencial = new CategoriaDeQuarto { Nome = "Presidencial", ValorDaDiaria = 300 };
            DAO.Save(categoriaDeQuartoPresidencial);

            // Quartos
            var quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoPresidencial, Estado = Quarto.EstadoDeQuarto.EmLimpeza, Numero = 40 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoPresidencial, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 41 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoTriplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 30 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoTriplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 31 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoTriplo, Estado = Quarto.EstadoDeQuarto.EmManutencao, Numero = 32 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoTriplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 33 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoDuplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 20 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoDuplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 21 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoDuplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 22 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoDuplo, Estado = Quarto.EstadoDeQuarto.EmLimpeza, Numero = 23 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoDuplo, Estado = Quarto.EstadoDeQuarto.EmManutencao, Numero = 24 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoDuplo, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 25 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoSimples, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 10 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoSimples, Estado = Quarto.EstadoDeQuarto.EmLimpeza, Numero = 11 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoSimples, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 12 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoSimples, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 13 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoSimples, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 14 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoSimples, Estado = Quarto.EstadoDeQuarto.EmLimpeza, Numero = 15 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoEconomico, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 1 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoEconomico, Estado = Quarto.EstadoDeQuarto.EmLimpeza, Numero = 2 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoEconomico, Estado = Quarto.EstadoDeQuarto.EmManutencao, Numero = 3 };
            DAO.Save(quarto);

            quarto = new Quarto() { CategoriaDeQuarto = categoriaDeQuartoEconomico, Estado = Quarto.EstadoDeQuarto.Disponivel, Numero = 4 };
            DAO.Save(quarto);
        
        }


    }
}