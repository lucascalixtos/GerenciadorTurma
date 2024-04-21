using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using GerenciadorTurma.FrontEnd.Models;
using GerenciadorTurma.FrontEnd.Models.Interfaces;

namespace GerenciadorTurma.FrontEnd.Data
{
    public class AlunoService: IAlunoService
    {
        private readonly HttpClient _httpClient;

        public AlunoService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7210/Aluno"); // URL base da sua API
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Aluno>> BuscarTodosAlunos()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Aluno/BuscarTodosAlunos");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Aluno>>(data);
            }
            return new List<Aluno>();
        }

        public async Task<Aluno> BuscarAluno(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("Aluno/BuscarAluno?id=" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Aluno>(data);
            }
            return new Aluno();
        }

        public async Task<bool> ApagarAluno(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync("Aluno/ApagarAluno?id=" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }

        public async Task<bool> CriarAluno(Aluno aluno)
        {
            var json = JsonConvert.SerializeObject(aluno);
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("Aluno/CriarAluno", conteudo);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }

        public async Task<bool> EditarAluno(Aluno aluno)
        {
            var json = JsonConvert.SerializeObject(aluno);
            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("Aluno/EditarAluno", conteudo);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(data);
            }
            return false;
        }
    }


}
