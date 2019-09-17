using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        //crud
        //hmmkkkbjs

        
        public List<Estudio> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudio.ToList();
            }
        }

        // insert into categorias (nome) values (@nome);
        public void Cadastrar (Estudio estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudio.Add(estudio);
                ctx.SaveChanges();
            }
        }



        public Estudio BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudio.FirstOrDefault(x => x.Idestudio == id);

            }
        }


        public void Atualizar(Estudio estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudio EstudioBuscado = ctx.Estudio.FirstOrDefault(x => x.Idestudio == estudio.Idestudio);
                // update categorias set nome = @nome
                EstudioBuscado.Estudio1 = estudio.Estudio1;
                // insert - add, delete - remove, update - update
                ctx.Estudio.Update(EstudioBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                // encontrar o item
                // chave primaria da tabela
                Estudio Estudio = ctx.Estudio.Find(id);
                // remover do contexto
                ctx.Estudio.Remove(Estudio);
                // efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }
    }
}
