using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Entity.Lista;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GetListas();
        }

        private async void GetListas()
        {
            Uri uri = new Uri("http://localhost:63879/api/ListaAPI");

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var listaJsonString = await response.Content.ReadAsStringAsync();
                        gridLista.DataSource = JsonConvert.DeserializeObject<ListaEntity[]>(listaJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter a lista : " + response.StatusCode);
                    }
                }
            }
        }

        private async void CriarLista()
        {
            Uri uri = new Uri("http://localhost:63879/api/ListaAPI");

            ListaEntity entity = new ListaEntity();
            entity.Nome = txtNome.Text;
            entity.Ativo = chkAtivo.Checked;
            
            using (var client = new HttpClient())
            {
                var serializedLista = JsonConvert.SerializeObject(entity);
                var content = new StringContent(serializedLista, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(uri, content);
            }

            GetListas();

            LimparForm();
        }

        private void btnListas_Click(object sender, EventArgs e)
        {
            GetListas();
        }

        private void btnCriarLista_Click(object sender, EventArgs e)
        {
            CriarLista();
        }

        private void LimparForm()
        {
            txtNome.Text = "";
            chkAtivo.Checked = false;
        }
    }
}