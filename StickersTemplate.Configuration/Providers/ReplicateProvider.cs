using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using StickersTemplate.Configuration.Models;
using StickersTemplate.Configuration.Providers;
using StickersTemplate.Configuration.Providers.Replicate;

namespace StickersTemplate.Configuration.Providers
{
    public class ReplicateProvider
    {
        private const string URL = "https://api.replicate.com/v1/predictions";
        private const string AUTH = "Token <update with your token>";

        private static string GetModelVer(string modelName)
        {
            switch (modelName)
            {
                case "comics1":
                    return "3b95347ce81b6bfdf4613dd1093b86d75d5effe21c2f1a1fe0ec301ee023d424";
                case "comics2":
                    return "2a1ebe3c0ba61c66047cf10540f443e334c163346494f65a0a14dd134e3026c9";
                case "anime":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                case "pixar":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                case "shrek":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                case "mona_lisa":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                case "joker":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                case "modigliani":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                case "witcher":
                    return "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                default:
                    throw new ArgumentException("Bad model name: " + modelName);
            };
        }
        public static string Generate(string modelName, string imgStr)
        {
            //get version
            string version = GetModelVer(modelName);
            string data = "";
            //switch version to fill in dto
            //prepare input
            switch (version)
            {
                case "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571":
                    var dto1 = new StyleganNadaInput();
                    var reqDto1 = new StyleganNadaReq();
                    dto1.input = imgStr;
                    dto1.output_style = "list - enter below";
                    dto1.style_list = modelName;
                    dto1.generate_video = false;
                    dto1.with_editing = false;
                    reqDto1.version = "c3584f3661ecd62f7fc1605af40220c102b0becd740a27d4d86d178b6bf32571";
                    reqDto1.input = dto1;
                    data = JsonConvert.SerializeObject(reqDto1, Formatting.None);
                    break;
                case "2a1ebe3c0ba61c66047cf10540f443e334c163346494f65a0a14dd134e3026c9":
                    var dto2 = new Photo2cartoonInput();
                    var reqDto2 = new Photo2cartoonReq();
                    dto2.photo = imgStr;
                    reqDto2.version = "2a1ebe3c0ba61c66047cf10540f443e334c163346494f65a0a14dd134e3026c9";
                    reqDto2.input = dto2;
                    data = JsonConvert.SerializeObject(reqDto2, Formatting.None);
                    break;
                case "3b95347ce81b6bfdf4613dd1093b86d75d5effe21c2f1a1fe0ec301ee023d424":
                    var dto3 = new Selfie2animeInput();
                    var reqDto3 = new Selfie2animeReq();
                    dto3.image = imgStr;
                    reqDto3.version = "3b95347ce81b6bfdf4613dd1093b86d75d5effe21c2f1a1fe0ec301ee023d424";
                    reqDto3.input = dto3;
                    data = JsonConvert.SerializeObject(reqDto3, Formatting.None);
                    break;
                default:
                    throw new ArgumentException("Bad version");
            }
            //POST with auth header
            return doPost(data);
        }
        public static string GetImage(string resId)
        {
            // GET api for the result
            int retryCnt = 5;
            string fileUrl = "";
            string response = "";
            // wait for 5 secs
            System.Threading.Thread.Sleep(3000);
            do
            {
                retryCnt -= 1;
                System.Threading.Thread.Sleep(3000);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL+"/"+resId);
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", AUTH);
                request.Timeout = 3000;

                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    response = responseReader.ReadToEnd();
                }
                if (((HttpWebResponse)webResponse).StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var resDto = JsonConvert.DeserializeObject<ResponseDTO>(response);
                    if (String.Equals(resDto.status, "succeeded"))
                    {
                        fileUrl = resDto.output[0].file;
                    }
                    else if(String.Equals(resDto.status, "failed"))
                    {
                        throw new Exception($"Generate Failed: {response}, input: {resId}");
                    }
                }
                else
                {
                    throw new Exception($"Error: {response}, input: {resId}");
                }
                
            } while (retryCnt > 0 && fileUrl.Length == 0);

            if (fileUrl == null || fileUrl.Length == 0)
            {
                throw new Exception($"File url not found... {response}");
            }
            return fileUrl;
        }
        private static string doPost(string data)
        {
            string resId = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", AUTH);
            request.Accept = "application/json";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(data);
            }


            WebResponse webResponse = request.GetResponse();

            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                string response = responseReader.ReadToEnd();
                if (((HttpWebResponse)webResponse).StatusCode == System.Net.HttpStatusCode.OK
                    || ((HttpWebResponse)webResponse).StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var resDto = JsonConvert.DeserializeObject<ResponseDTO>(response);
                    resId = resDto.id;
                }
                else if (((HttpWebResponse)webResponse).StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new ArgumentException($"Error: {response}, input: {data}");
                }
                else
                {
                    throw new Exception($"Error: {response}, input: {data}");
                }
            }

            return resId;
        }

    }
}