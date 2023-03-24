using EscolaDotNet.EntityConfigs;
using EscolaDotNet.Models;
using Microsoft.EntityFrameworkCore;
namespace EscolaDotNet.Contexts;

public class AppDbContext : DbContext
{ //representa o banco

    public DbSet<Curso> Cursos => Set<Curso>();//representa a tabela

    //E a Conexão?
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {

       // builder.UseSqlServer("Server=LAB-F08-28;Database=EscolaDotNet;User Id=sa;Password=senai@123;TrustServerCertificate=True;");
       builder.UseSqlServer("Server=VAIAMANHECER\\SQLEXPRESS;Database=EscolaDotNet;Integrated Security=True;TrustServerCertificate=True;");

    }

    protected override void OnModelCreating(ModelBuilder builder){
        builder.ApplyConfiguration(new CursoEntityConfig());
    }







}