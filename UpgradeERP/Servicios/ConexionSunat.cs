using Newtonsoft.Json;
using System.Net;
using UpgradeERP.Models.ApiSunat;

namespace UpgradeERP.Servicios
{
    public class ConexionSunat
    {

        public async Task<DniORuc> ObtenerDNI(string dni)
        {
            try
            {
                string DNI = dni;
                string coec = "https://api.apis.net.pe/v1/dni?numero=" + dni;

                DniORuc di = new DniORuc();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(coec);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reander = new StreamReader(stream))
                {
                    var json = reander.ReadToEnd();
                    di = JsonConvert.DeserializeObject<DniORuc>(json);
                }

                return di;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DniORuc> ObtenerRUC(string ruc)
        {
            try
            {
                string RUC = ruc;
                string coec = "https://api.apis.net.pe/v1/ruc?numero=" + ruc;

                DniORuc ru = new DniORuc();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(coec);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reander = new StreamReader(stream))
                {
                    var json = reander.ReadToEnd();
                    ru = JsonConvert.DeserializeObject<DniORuc>(json);
                }

                return ru;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
