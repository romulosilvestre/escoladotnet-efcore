using EscolaDotNet.Models;
namespace EscolaDotNet.ViewModels;
public class ListaCursoViewModel{

    //Listas ou Coleções

    /*
    Alguem já fez coleção de alguma coisa (esquece programação)
       Figurinhas

       ICollection<Card> Album {get;set;} = new List<Card>();
      
    */
    public ICollection<Curso> Cursos {get;set;} = new List<Curso>();

}