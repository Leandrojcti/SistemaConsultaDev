using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SistemaConsultaDev.Models;
using System.Diagnostics;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using iText.Html2pdf;
using iText.Kernel.Pdf;


namespace SistemaConsultaDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Metodo Leitura txt (Usa a biblioteca iTextSharp Adicionada pelo Nuget)

        public IActionResult LeituraGeral(String NomeArquivo)
        {
            string Caminho = Path.Combine("C:/Estudos Programação/SistemaConsultaDev/SistemaConsultaDev/ConteudosTXT/" + NomeArquivo + ".txt");
            String[] Conteudo = System.IO.File.ReadAllLines(Caminho);

            ViewData["NomeArquivo"] = NomeArquivo;

            return View((object)Conteudo);

        }

      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
