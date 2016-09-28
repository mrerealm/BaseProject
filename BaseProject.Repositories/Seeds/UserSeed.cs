using System.Data.Entity.Migrations;
using BaseProject.Domain.Entities;
using BaseProject.Domain.Enuns;
using BaseProject.Domain.ValueObject;

namespace BaseProject.Repositories.Seeds
{
    public class UserSeed
    {
        public static void Seed(EfDbContext context)
        {
            var endereco = new Endereco("Rua teste", "complemento teste", "numero teste", "bairroteste", "cidadeteste",
                Uf.SP, new Cep("06414-110"));

            context.Users.AddOrUpdate(x => x.Login,
                new User("adminMaster", new Cpf("40914294830"), new Email("email@gmail.com"), "testeteste", "testeteste", endereco));
        }
    }
}
