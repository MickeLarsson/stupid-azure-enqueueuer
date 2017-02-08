using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace laget.azure_enquer
{
    public interface IAzureEnquer
    {
        void Enqueue(string queueName, dynamic msg);
        void Enqueue(string queueName, string msg);
    }

    public class AzureEnquer : IAzureEnquer
    {
        readonly CloudQueueClient _client;

        public AzureEnquer(string cloudStorageAccountConnStr)
        {
            var storageAccount = CloudStorageAccount.Parse(cloudStorageAccountConnStr);
            _client = storageAccount.CreateCloudQueueClient();
        }

        public void Enqueue(string queueName, dynamic msg)
        {
            Enqueue(queueName, JsonConvert.SerializeObject(msg));
        }

        public void Enqueue(string queueName, string msg)
        {
            var queue = _client.GetQueueReference(queueName);
            queue.CreateIfNotExists();

            var message = new CloudQueueMessage(JsonConvert.SerializeObject(msg));
            queue.AddMessage(message);
        }
    }
}
