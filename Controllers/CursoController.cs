using EscolaDotNet.Contexts;
using EscolaDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EscolaDotNet.Models;

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
    public IActionResult Delete(int id){
        var curso = _context.Cursos.Find(id);
        if(curso is null){
            return NotFound();
        }
        _context.Remove(curso);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create(){
        ViewData["Title"] = "Cadastrar Curso";
        return View();
    }
    [HttpPost]
    public IActionResult Create(CreateCursoViewModel data){
        var curso = new Curso(data.Nome,
                                data.Titulo,
                                data.Descricao,
                                data.Perfil,
                                data.PreRequisitos,
                                data.Conteudo,
                                data.Recursos,
                                data.CargaHoraria,
                                data.PrazoMeses);

        _context.Add(curso);
        _context.SaveChanges();
        //Quero redirecionar de volta pra Index
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id){
        ViewData["Title"] = "Editar Curso";
        var curso = _context.Cursos.Find(id);
        if(curso is null){
            return NotFound();
        }
        var viewModel = new EditCursoViewModel{
           Id = curso.Id,
           Nome = curso.Nome,
           CargaHoraria = curso.CargaHoraria,
           Conteudo = curso.Conteudo,
           Descricao = curso.Descricao,
           Perfil = curso.Perfil,
           PrazoMeses = curso.PrazoMeses,
           PreRequisitos = curso.PreRequisitos,
           Recursos = curso.Recursos,
           Titulo = curso.Titulo

        };
        return View(viewModel);
    }

}

