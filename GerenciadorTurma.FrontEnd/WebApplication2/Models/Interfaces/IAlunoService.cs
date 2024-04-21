namespace GerenciadorTurma.FrontEnd.Models.Interfaces
{
    public interface IAlunoService
    {
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<Aluno> BuscarAluno(int id);
        Task<bool> ApagarAluno(int id);
        Task<bool> CriarAluno(Aluno aluno);
        Task<bool> EditarAluno(Aluno aluno);
    }
}
