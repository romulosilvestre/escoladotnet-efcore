using EscolaDotNet.Contexts;
using EscolaDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDotNet.Controllers;

public class CursoController:Controller{   

    private readonly AppDbContext _context;
   
    public CursoController(AppDbContext context){
     //Injeção de dependência: você vai deixar o framework resolver a questão da instanciação
     //AppDbContext c = new AppDbContext(); --> A injeção de dependência em síntese fica responsável pelo new
         _context = context;    
    }
    public IActionResult Index(){
        //lista de cursos
        var cursos = _context.Cursos.ToList();

        //já tenho meu ViewModel
        var viewModel = new ListaCursoViewModel{Cursos = cursos};
        return View(viewModel);
    }

}

