// See https://aka.ms/new-console-template for more information


using AulaEntity;
using AulaEntity.model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine(@" 
    Informe 1 para criar uma pessoa,
    Informe 2 para alterar o nome,
    Informe 3 para inserir um email,
    Informe 4 para excluir a pessoa,
    Informe 5 para consultar todas as pessoas,
    Informe 6 para consultar pelo ID");

int op = int.Parse(Console.ReadLine());

Contexto contexto = new Contexto();

switch (op)
{
    case 1:
        try
        {
            Pessoa p = new Pessoa();
            Console.WriteLine("Insira o nome da pessoa: ");
            p.nome = Console.ReadLine();
            Console.WriteLine("Insira o email da pessoa: ");
            Email email = new Email();
            email.email = Console.ReadLine();
            
            p.Emails = new List<Email>();//iniciar a lista
            p.Emails.Add(email);//adicionar o email

            contexto.Pessoas.Add(p);
            contexto.SaveChanges();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            
        }
        break;
    case 2:
        Console.WriteLine("Informe o ID da pessoa: ");
        int idPessoa2 = int.Parse(Console.ReadLine());
        Pessoa pAlt = contexto.Pessoas.Find(idPessoa2);
        Console.WriteLine("Informe um novo nome: ");
        pAlt.nome = Console.ReadLine();
        contexto.Pessoas.Update(pAlt);
        contexto.SaveChanges();
        break;
    case 3:
        Console.WriteLine("Informe o ID da pessoa: ");
        int idPessoa3 = int.Parse(Console.ReadLine());
        Pessoa pEmail = contexto.Pessoas.Find(idPessoa3);
        Console.WriteLine("Informe um novo email: ");
        Email emailNovo = new Email();
        emailNovo.email = Console.ReadLine();

        if (pEmail.Emails == null)
        {
            pEmail.Emails = new List<Email>();
        }
       
        pEmail.Emails.Add(emailNovo);
        contexto.Pessoas.Update(pEmail);
        contexto.SaveChanges();

        break;

    case 4:
        Console.WriteLine("Informe o ID da pessoa: ");
        int idPessoaExc = int.Parse(Console.ReadLine());
        Pessoa pExc = contexto.Pessoas.Find(idPessoaExc);

        Console.WriteLine("Confirma a exclusão de " + pExc.nome);
        Console.WriteLine(" E dde seus emails: ");
        foreach (Email item in pExc.Emails)
        {
            Console.WriteLine("    " + item.email);
        }

        Console.WriteLine("1 -- Sim" +
            "2 -- Não");
        int retorno = int.Parse(Console.ReadLine());

        if (retorno == 1)
        {
            contexto.Pessoas.Remove(pExc);
            contexto.SaveChanges();
        }


        break;

    case 5:

        List<Pessoa> pessoas = new List<Pessoa>();
        pessoas = (from Pessoa p in contexto.Pessoas select p).Include(e => e.Emails ).ToList<Pessoa>();
        foreach (Pessoa pessoaItem in pessoas)
        {
            Console.WriteLine(pessoaItem.nome);
            foreach (Email emailItem in pessoaItem.Emails)
            {
                Console.WriteLine("--- "+ emailItem.email);
                Console.WriteLine();
            }
        }

        break;
    case 6:
       
        Console.WriteLine("Informe o ID da pessoa: ");
        int idPessoa = int.Parse(Console.ReadLine());
        Pessoa pId = contexto.Pessoas.Include(p => p.Emails).FirstOrDefault(p => p.id == idPessoa);
        Console.WriteLine(pId.nome);
        foreach (Email emailItem in pId.Emails)
        {
            Console.WriteLine("--- " + emailItem.email);
            Console.WriteLine();
        }

        break;
    default:
        break;
}

