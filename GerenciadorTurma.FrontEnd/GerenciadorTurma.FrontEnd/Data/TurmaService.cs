using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using GerenciadorTurma.FrontEnd.Models;
using GerenciadorTurma.FrontEnd.Models.Interfaces;

namespace GerenciadorTurma.FrontEnd.Data
{
    public class TurmaService : ITurmaService
    {
        private readonly HttpClient _httpClient;

        public TurmaService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7210/Turma"); // URL base da sua API
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Turma>> BuscarTodosTurmas()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Turma/BuscarTodosTurmas");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Turma>>(data);
            }
            return new List<Turma>();
        }

        public async Task<Turma> BuscarTurma(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Turma/BuscarTurma?id=" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Turma>(data);
            }
            return new Turma();
        }

        public async Task<bool> ApagarTurma(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Turma/ApagarTurma?id=" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }

        public async Task<bool> CriarTurma(Turma Turma)
        {
            var json = JsonConvert.SerializeObject(Turma);
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("Turma/CriarTurma", conteudo);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }

        public async Task<bool> EditarTurma(Turma Turma)
        {
            var json = JsonConvert.SerializeObject(Turma);
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("Turma/EditarTurma", conteudo);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }

        public async Task<AlunoTurma> BuscarAlunosEmTurma(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Turma/BuscarAlunosEmTurma?idTurma=" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AlunoTurma>(data);
            }
            return new AlunoTurma();
        }

        public async Task<bool> AdicionarAlunoaTurma(int idAluno, int idTurma)
        {

            HttpResponseMessage response = await _httpClient.PostAsync("Turma/AdicionarAlunoaTurma?idAluno=" + idAluno.ToString() + "&idTurma=" + idTurma.ToString(), null);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }

        public async Task<bool> RemoverAlunoDeTurma(int idAluno, int idTurma) 
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Turma/RemoverAlunoDeTurma?idAluno=" + idAluno.ToString() + "&idTurma=" + idTurma.ToString());

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }


    }
}
