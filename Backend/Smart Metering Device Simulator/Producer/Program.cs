using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

var factory = new ConnectionFactory { HostName = "3.135.27.91" };
var conn = factory.CreateConnection();

//ConnectionFactory factory = new ConnectionFactory();
//factory.UserName = "alisheikh";
//factory.Password = "alisheikh";
//factory.VirtualHost = "/";
//factory.HostName = "http://3.135.27.91";
//factory.Port = 15672;
//IConnection conn = factory.CreateConnection();


var channel = conn.CreateModel();
channel.QueueDeclare(queue: "letterbox", durable: false, exclusive: false, autoDelete: false, arguments: null);
var message = "Hello";
var encodeMessage = Encoding.Default.GetBytes(JsonConvert.SerializeObject(Regex.Replace(message, @"\s+", "")));
channel.BasicPublish("", "letterbox", null, encodeMessage);