using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Lab1ClassLibrary;

namespace Lab1WebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService 
    {

        [WebMethod]
        public string SayHello(string name)
        {
            return "Hello, " + name + "!";
        }

        [WebMethod]
        public ResultadoJogo[] ComplexMethod()
        {
            ResultadoJogo[] resultadoJogo = new ResultadoJogo[2];

            resultadoJogo[0] = new ResultadoJogo();
            resultadoJogo[0].casa = "Atlético Paranaense";
            resultadoJogo[0].golCasa = 6;
            resultadoJogo[0].visitante = "Milan";
            resultadoJogo[0].golVisitante = 0;

            resultadoJogo[1] = new ResultadoJogo();
            resultadoJogo[1].casa = "Atlético Paranaense";
            resultadoJogo[1].golCasa = 5;
            resultadoJogo[1].visitante = "Chelsea";
            resultadoJogo[1].golVisitante = 1;

            return resultadoJogo;

        }
    }
}