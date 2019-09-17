using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogo> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogo.ToList();
            }
        }

        public  void Cadastrar(Jogo jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogo.Add(jogo);
                ctx.SaveChanges();
            }
        }
        
        public Jogo BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogo.FirstOrDefault(x => x.Idjogo == id);
            }
        }

        public void Atualizar(Jogo jogo)
        {
            using (InLockContext ctx = new InLockContext())

            {
                Jogo JogoBuscado = ctx.Jogo.FirstOrDefault(x => x.Idjogo == jogo.Idjogo);
                // update categorias set nome = @nome
                JogoBuscado.Jogo1 = jogo.Jogo1;
                // insert - add, delete - remove, update - update
                ctx.Jogo.Update(JogoBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public void Deletar (int Id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogo jogo = ctx.Jogo.Find(Id);
                ctx.Jogo.Remove(jogo);
                ctx.SaveChanges();
            }
        }

    }
}
