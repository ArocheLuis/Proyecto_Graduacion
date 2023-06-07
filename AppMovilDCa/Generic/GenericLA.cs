using AppMovilDCa.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMovilDCa.Generic
{
    public class GenericLA
    {
        public static async Task<List<T>> GetAll<T>(string url)
        {
            HttpClient cliente = new HttpClient();
            var rpta = await cliente.GetAsync(url);
            if (!rpta.IsSuccessStatusCode) return new List<T>();
            else
            {
                //Como String
                var result = await rpta.Content.ReadAsStringAsync();
                List<T> l = JsonConvert.DeserializeObject<List<T>>(result);
                return l;
            }

        }
        public static async Task<int> Post<T>(string url, T obj)
        {
            HttpClient cliente = new HttpClient();
            var cadena = JsonConvert.SerializeObject(obj);
            var body = new StringContent(cadena, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("http://luisaroche-001-site1.atempurl.com/api/Finca", body);
            if (!response.IsSuccessStatusCode) return 0;
            else
            {
                int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
                return respuesta;
            }


        }
        public static async Task<int> Postp<T>(string url, T obj)
        {
            HttpClient cliente = new HttpClient();
            var cadena = JsonConvert.SerializeObject(obj);
            var body = new StringContent(cadena, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("http://luisaroche-001-site1.atempurl.com/api/Persona", body);
            if (!response.IsSuccessStatusCode) return 0;
            else
            {
                int respuesta = int.Parse(await response.Content.ReadAsStringAsync());
                return respuesta;
            }


        }

        public static async Task<int> Delete(string url)
        {
            HttpClient cliente = new HttpClient();
            var rpta = await cliente.DeleteAsync(url);
            if (!rpta.IsSuccessStatusCode) return 0;
            else
            {
                //Cadena(1 -> Exitoso , 0->Error) ->int ""
                var result = await rpta.Content.ReadAsStringAsync();
                return int.Parse(result);
            }
            

        }
    }
}
