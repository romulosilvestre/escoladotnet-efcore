using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscolaDotNet.Models;
using EscolaDotNet.ViewModels;

namespace EscolaDotNet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //var - declaração da variável
        //new - operador de instanciação
        //Curso( ) - chamada ao Construtor da classe Curso
        //Construtor - construir o objeto na memória.
       
        var curso = new Curso(){ //
           //Mock (dados de teste - fictício)
           //Propriedades automáticas
           Id =1,
           Nome = "Introdução à Programação",
           Titulo = "Primeiros passos na programação",
           Descricao = "Fundamentos de programação e algoritmos estruturados",
           Perfil ="estudantes e aprendizes no geral",
           PreRequisitos ="informática básica",
           Conteudo = "1-introdução 2-lógica 3-estruturas 4-vetores 5-funções 6-matrizes 7-estruturas de dados 8-registros",
           CargaHoraria = 40,
           PrazoMeses = 1

        };
        //ViewDataDictionary
        //chave - valor
    //    ViewData["curso"] = curso; //recurso de chave : valor
        ViewData["Title"] = "Página principal";
        ViewBag.Curso = curso;
        TempData["mensagem"] ="Mensagem vinda da Action Index";
        //int ch =40;
        //Dicionário (ViewDataDictionary)
        /*ViewData["nome"] ="TI Essencial";
        ViewData["titulo"]="Uma visão geral da TI";
        ViewData["ch"] = $"Teremos {ch} horas de imersão nos fundamentos da TI";
        ViewData["descricao"] = "Nesse curso você vai aprender os primeiros passos na tecnologia da informação, conhecer o hardware, software, redes, protocolos e conhecimentos básicos para depois mergulhar no mundo do desenvolvimento de software da Microsoft";
        /*
          Para transportar dados de um controller para uma View
          Podemos usar ViewData, ViewBag e TempData

          Competência ViewData
          Competência ViewBag
          Competência TempData

        */


        /*
           TempData[] - a diferença do TempData para ViewData[] e ViewBag é que a primeira mantém o valor dentro da sessão

           *Bradesco
           *ToTvs
           *Itau
           *

       
        */
        return View(); //View página web (*resposta)
    }

    public IActionResult Mensagem(){
        return View();
    }

    public IActionResult ViewModel(){
      //copie e cole o curso da outra Action pois já tinhamos criado

       var curso = new Curso(){ //
           //Mock (dados de teste - fictício)
           //Propriedades automáticas
           Id =1,
           Nome = "Introdução à Programação",
           Titulo = "Primeiros passos na programação",
           Descricao = "Fundamentos de programação e algoritmos estruturados",
           Perfil ="estudantes e aprendizes no geral",
           PreRequisitos ="informática básica",
           Conteudo = "1-introdução 2-lógica 3-estruturas 4-vetores 5-funções 6-matrizes 7-estruturas de dados 8-registros",
           CargaHoraria = 40,
           PrazoMeses = 1

        };
        var viewModel = new DetalhesCursoViewModel
        {
            Curso = curso,
            TituloPagina = "Detalhes do Curso"
            
        };
        return View(viewModel); //passar um objeto pra view
        //ViewData[]- nãoaoaoaaoaoaaoaoao
        //ViewBag -naãoaoaoaoaoaoa
        //TempData[ ] d------
        //ViewModel ---sismsmkssssk
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
