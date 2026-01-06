using BibliotecaISLA.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaISLA.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BibliotecaContext(
                serviceProvider.GetRequiredService<DbContextOptions<BibliotecaContext>>()))
            {
                // Verificar se já existem dados
                if (context.Autor.Any())
                {
                    return; // BD já foi populada
                }

                // Criar Autores
                var autores = new Autor[]
                {
                    new Autor
                    {
                        Nome = "José Saramago",
                        Nacionalidade = "Portuguesa",
                        DataNascimento = DateTime.Parse("1922-11-16")
                    },
                    new Autor
                    {
                        Nome = "J.K. Rowling",
                        Nacionalidade = "Britânica",
                        DataNascimento = DateTime.Parse("1965-07-31")
                    },
                    new Autor
                    {
                        Nome = "Fernando Pessoa",
                        Nacionalidade = "Portuguesa",
                        DataNascimento = DateTime.Parse("1888-06-13")
                    },
                    new Autor
                    {
                        Nome = "Agatha Christie",
                        Nacionalidade = "Britânica",
                        DataNascimento = DateTime.Parse("1890-09-15")
                    }
                };

                context.Autor.AddRange(autores);
                context.SaveChanges();

                // Criar Livros
                var livros = new Livro[]
                {
                    new Livro
                    {
                        Titulo = "Ensaio sobre a Cegueira",
                        ISBN = "978-9722011426",
                        AnoPublicacao = 1995,
                        AutorID = autores[0].AutorID
                    },
                    new Livro
                    {
                        Titulo = "Harry Potter e a Pedra Filosofal",
                        ISBN = "978-9722325810",
                        AnoPublicacao = 1997,
                        AutorID = autores[1].AutorID
                    },
                    new Livro
                    {
                        Titulo = "Livro do Desassossego",
                        ISBN = "978-8535911664",
                        AnoPublicacao = 1982,
                        AutorID = autores[2].AutorID
                    },
                    new Livro
                    {
                        Titulo = "Assassinato no Expresso do Oriente",
                        ISBN = "978-8595084865",
                        AnoPublicacao = 1934,
                        AutorID = autores[3].AutorID
                    },
                    new Livro
                    {
                        Titulo = "Memorial do Convento",
                        ISBN = "978-9722016032",
                        AnoPublicacao = 1982,
                        AutorID = autores[0].AutorID
                    }
                };

                context.Livro.AddRange(livros);
                context.SaveChanges();

                // Criar Membros
                var membros = new Membro[]
                {
                    new Membro
                    {
                        Nome = "Ana Silva",
                        Email = "ana.silva@email.com",
                        DataInscricao = DateTime.Parse("2023-01-10")
                    },
                    new Membro
                    {
                        Nome = "Carlos Santos",
                        Email = "carlos.santos@email.com",
                        DataInscricao = DateTime.Parse("2023-02-15")
                    },
                    new Membro
                    {
                        Nome = "Maria Costa",
                        Email = "maria.costa@email.com",
                        DataInscricao = DateTime.Parse("2023-03-20")
                    },
                    new Membro
                    {
                        Nome = "João Pereira",
                        Email = "joao.pereira@email.com",
                        DataInscricao = DateTime.Parse("2023-04-05")
                    }
                };

                context.Membro.AddRange(membros);
                context.SaveChanges();

                // Criar Empréstimos
                var emprestimos = new Emprestimo[]
                {
                    new Emprestimo
                    {
                        LivroID = livros[0].LivroID,
                        MembroID = membros[0].MembroID,
                        DataEmprestimo = DateTime.Parse("2024-05-01"),
                        DataDevolucao = DateTime.Parse("2024-05-15")
                    },
                    new Emprestimo
                    {
                        LivroID = livros[1].LivroID,
                        MembroID = membros[1].MembroID,
                        DataEmprestimo = DateTime.Parse("2024-05-10"),
                        DataDevolucao = null
                    },
                    new Emprestimo
                    {
                        LivroID = livros[2].LivroID,
                        MembroID = membros[0].MembroID,
                        DataEmprestimo = DateTime.Parse("2024-05-20"),
                        DataDevolucao = DateTime.Parse("2024-05-25")
                    },
                    new Emprestimo
                    {
                        LivroID = livros[3].LivroID,
                        MembroID = membros[2].MembroID,
                        DataEmprestimo = DateTime.Parse("2024-05-25"),
                        DataDevolucao = null
                    },
                    new Emprestimo
                    {
                        LivroID = livros[0].LivroID,
                        MembroID = membros[3].MembroID,
                        DataEmprestimo = DateTime.Parse("2024-06-01"),
                        DataDevolucao = null
                    }
                };

                context.Emprestimo.AddRange(emprestimos);
                context.SaveChanges();
            }
        }
    }
}