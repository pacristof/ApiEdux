using ProjetoEduxG8.Interface;
using ProjetoEduXG8.Context;
using ProjetoEduXG8.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxG8.Repositories
{

    public class AlunoTurmaRepository : iAlunoTurma
    {
        private readonly EduXContext _ctx;

        public AlunoTurmaRepository()
        {
            _ctx = new EduXContext();
        }

        public void Adicionar(AlunoTurma alunoTurma)
        {
            try
            {
                _ctx.AlunoTurma.Add(alunoTurma);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public AlunoTurma BuscarPorId(Guid id)
        {
            try
            {
                AlunoTurma alunoTurma = _ctx.AlunoTurma.Find(id);

                return alunoTurma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(AlunoTurma alunoTurma)
        {
            try
            {
                AlunoTurma alunoTurmaTemp = BuscarPorId(alunoTurma.IdAlunoTurma);

                if (alunoTurmaTemp == null)
                    throw new Exception("Aluno não encontrado");

                alunoTurmaTemp.IdUsuario = alunoTurma.IdUsuario;
                alunoTurmaTemp.IdTurma = alunoTurma.IdTurma;

                _ctx.AlunoTurma.Update(alunoTurmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AlunoTurma> Listar()
        {
            try
            {
                List<AlunoTurma> alunoTurma = _ctx.AlunoTurma.ToList();

                return alunoTurma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                AlunoTurma alunoTurma = BuscarPorId(id);

                if (alunoTurma == null)
                    throw new Exception("Aluno não encontrado");

                _ctx.AlunoTurma.Remove(alunoTurma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}