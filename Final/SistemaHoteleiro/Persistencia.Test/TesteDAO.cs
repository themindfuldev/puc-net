using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Modelo.Dominio;
using NUnit.Framework;
using Persistencia.ORM;

namespace Persistencia.Test
{
    [TestFixture]
    public class TesteDAO
    {
        [Test]
        public void TesteObterCategoriasDeQuarto()
        {
            var categoriasDeQuarto = DAO.GetAll("Modelo.Dominio.CategoriaDeQuarto,Modelo") as IList;
            Console.WriteLine("DAO.GetAll('CategoriaDeQuarto'):");
            foreach (var categoria in categoriasDeQuarto)
            {
                Console.WriteLine(categoria.ToString());
            }
        }

        [Test]
        public void TesteObterQuartos()
        {
            var quartos = DAO.GetAll("Modelo.Dominio.Quarto,Modelo") as IList;
            Console.WriteLine("DAO.GetAll('Modelo.Dominio.Quarto,Modelo'):");
            foreach (var quarto in quartos)
            {
                Console.WriteLine(quarto.ToString());
            }
        }

    }
}
