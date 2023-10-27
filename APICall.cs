using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace agrostorefrontend.Classes
{
    public class APICall
    {
        public struct DbResponse
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }
        public struct OrderResponse
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string OrderCode { get; set; }
        }
        public struct FertilizerRequest
        {
            public string Name { get; set; }
            public float QuantityLimit { get; set; }
            public float UnitPrice { get; set; }
        }
        public struct SeedRequest
        {
            public string Name { get; set; }
            public float QuantityLimit { get; set; }
            public float UnitPrice { get; set; }
            public string FertilizerCode { get; set; }
        }
        public struct OrderRequest
        {
            public string FarmerName { get; set; }
            public string FarmerPhone { get; set; }
        }
        public struct OrderDetailsRequest
        {
            public string OrderCode { get; set; }
            public string ItemType { get; set; }
            public string CodeItem { get; set; }
            public float LandSize { get; set; }
        }

        public struct FertilizerData
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string QuantityLimit { get; set; }
            public string UnitPrice { get; set; }
            public bool Available { get; set; }
        }
        public struct SeedData
        {
            public string Code { get; set; }
            public string Name { get; set; }

            public string QuantityLimit { get; set; }
            public string UnitPrice { get; set; }
            public string Fertilizer { get; set; }
            public bool Available { get; set; }
        }
        public struct OrderData
        {
            public string OrderCode { get; set; }
            public string FarmerName { get; set; }
            public string FarmerPhone { get; set; }
            public string OrderDate { get; set; }
            public string OrderStatus { get; set; }
        }
        public struct OrderDetailsData
        {
            public int IdRecord { get; set; }

            public string ItemName { get; set; }
            public string CodeItem { get; set; }
            public string ItemType { get; set; }
            public string LandSize { get; set; }
            public string Quantity { get; set; }
            public string UnitPrice { get; set; }
            public string SubTotal { get; set; }

        }
        public struct updateOrderRequest
        {
            public string status { get; set; }
            public string OrderCode { get; set; }
        }
        public struct DeleteOrderDetailRequest
        {
            public int Idrecord { get; set; }
            public string OrderCode { get; set; }
        }
        public DataTable ListSettings(string EndPoint)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DataTable result = new DataTable();
            var ResponseData = string.Empty;
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "GET";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    ResponseData = reader.ReadToEnd();
                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    ResponseData = reader.ReadToEnd();
                }
            }
            result = (DataTable)JsonConvert.DeserializeObject(ResponseData, (typeof(DataTable)));
            return result;
        }
        public DbResponse CreateOrder(string EndPoint, OrderRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
        public DbResponse CreateOrderDetails(string EndPoint, OrderDetailsRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
        public DbResponse Update_Order_Status(string EndPoint, updateOrderRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
        public DbResponse Delete_OrderDetail(string EndPoint, DeleteOrderDetailRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
        public DbResponse DiscardOrder(string EndPoint, DeleteOrderDetailRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
        public DbResponse CreateFertilizer(string EndPoint, FertilizerRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
        public DbResponse CreateSeed(string EndPoint, SeedRequest requestData)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ConfigurationManager.AppSettings["APIUrl"] + "/" + EndPoint));
            DbResponse result = new DbResponse();
            var responseString = string.Empty;
            var json = JsonConvert.SerializeObject(requestData);
            var data = Encoding.ASCII.GetBytes(json);
            request.ProtocolVersion = HttpVersion.Version11;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            request.Method = "POST";
            request.Timeout = 1000000000;
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            try
            {

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException)
            {

                result.Code = "500";
                result.Message = "API Unreachable";
            }
            result = (DbResponse)JsonConvert.DeserializeObject(responseString, (typeof(DbResponse)));

            return result;
        }
    }
}