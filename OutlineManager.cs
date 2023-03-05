using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Generic;

using OutlineManager.Types;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace OutlineManager
{
    public class Outline
    {
        public static string ApiUrl;
        public static int KeysCount;
        public static bool HasSsl;

        /// <summary>
        /// Welcome to OutlineAPI Manager!
        /// </summary>
        /// <param name="apiUrl">URL for access to Management API</param>
        
        public Outline(string apiUrl)
        {
            ApiUrl = apiUrl;
            KeysCount = GetKeys().Count;
        }

        /// <param name="apiUrl">URL for access to Management API</param>
        /// <param name="hasSsl"><i>If your Outline Server hasn't <b>SSL connection</b> - set false</i></param>
        public Outline(string apiUrl, bool hasSsl)
        {
            ApiUrl = apiUrl;
            HasSsl = hasSsl;
            KeysCount = GetKeys().Count();
        }

        private static bool CallRequest(string urlMethod, string method, out string data)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiUrl + "/" + urlMethod);
                httpWebRequest.Method = method;
                if (HasSsl == false)
                    httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using Stream stream = httpWebResponse.GetResponseStream();
                    using StreamReader streamReader = new StreamReader(stream);
                    data = streamReader.ReadToEnd();
                }
                return true;
            }
            catch
            {
                data = null;
                return false;
            }
        }
        private static bool CallRequest(string urlMethod, string method, JObject args, out string data)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                data = webClient.UploadString($"{ApiUrl}/{urlMethod}", method, args.ToString());
                return true;
            }
            catch
            {
                data = null;
                return false;
            }
        }

        /// <summary>
        /// Get Outline Keys from Outline Server
        /// </summary>
        /// <returns>List of <see cref="T:OutlineManager.Types.OutlineKey" /></returns>
        public List<OutlineKey> GetKeys()
        {
            CallRequest("access-keys", "GET", out var data);
            return (JObject.Parse(data)["accessKeys"] as JArray).ToObject<List<OutlineKey>>();
        }
        /// <summary>
        /// Create Key in Outline Server
        /// </summary>
        /// <returns>Key information in <see cref="T:OutlineManager.Types.OutlineKey" /></returns>
        public OutlineKey CreateKey()
        {
            CallRequest("access-keys", "POST", out var data);
            return (JObject.Parse(data)).ToObject<OutlineKey>();
        }
        /// <summary>
        /// Delete Key from Outline Server by ID
        /// </summary>
        /// <param name="id">ID of key</param>
        /// <returns><see cref="true" />, if operation was successful</returns>
        public bool DeleteKey(int id)
        {
            bool operation = CallRequest("access-keys", "DELETE", out _);
            return operation;
        }
        /// <summary>
        /// Rename Key from Outline Server by ID
        /// </summary>
        /// <param name="id">ID of key</param>
        /// <param name="name">Name of key</param>
        /// <returns> <b><see cref="true" /></b>, if operation was successful</returns>
        public bool RenameKey(int id, string name)
        {
            bool operation = CallRequest($"access-keys/{id}/name",
                "PUT",
                new JObject
                {
                    { "name", name }
                }, out _);
            return operation;
        }
        /// <summary>
        /// Add Data Limit for Key from Outline Server by ID
        /// </summary>
        /// <param name="id">ID of key</param>
        /// <param name="limitBytes">Limit for key in <b>bytes</b></param>
        /// <returns> <b><see cref="true" /></b>, if operation was successful</returns>
        public bool AddDataLimit(int id, long limitBytes)
        {
            bool operation = CallRequest($"access-keys/{id}/data-limit",
                "PUT",
                new JObject
                {
                    {
                        "limit", new JObject
                        {
                            {"bytes", limitBytes}
                        }
                    }
                },
                out _);
            return operation;
        }
        /// <summary>
        /// Remove Data Limit for Key from Outline Server by ID
        /// </summary>
        /// <param name="id">ID of key</param>
        /// <returns> <b><see cref="true" /></b>, if operation was successful</returns>
        public bool DeteleDataLimit(int id)
        {
            bool operation = CallRequest($"access-keys/{id}/data-limit", "DELETE", out _);
            return operation;
        }
        /// <summary>
        /// Get Transferred Data from Outline Server
        /// </summary>
        /// <returns>List of keys in <see cref="T:OutlineManager.Types.TransferredData" /> with transferred data</returns>
        public List<TransferredData> GetTransferredData()
        {
            bool operation = CallRequest("metrics/transfer", "GET", out var data);
            var response = JObject.Parse(data)["bytesTransferredByUserId"] as JObject;
            List<TransferredData> list = new List<TransferredData>();
            foreach (var dat in response)
                list.Add(new TransferredData() { KeyId = int.Parse(dat.Key), UsedBytes = (long)dat.Value });
            return list;
        }
    }
}

