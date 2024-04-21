namespace GerenciadorTurma.FrontEnd.Models.Interfaces
{
    public interface ITurmaService
    {
        Task<List<Turma>> BuscarTodosTurmas();
        Task<Turma> BuscarTurma(int id);
        Task<bool> ApagarTurma(int id);
        Task<bool> CriarTurma(Turma Turma);
        Task<bool> EditarTurma(Turma Turma);
        Task<AlunoTurma> BuscarAlunosEmTurma(int id);
        Task<bool> AdicionarAlunoaTurma(int idAluno, int idTurma);
        Task<bool> RemoverAlunoDeTurma(int idAluno, int idTurma);


    }
}
