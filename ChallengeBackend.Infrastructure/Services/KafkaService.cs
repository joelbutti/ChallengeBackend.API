using System;
using System.Threading.Tasks;
using ChallengeBackend.Application.Interfaces;
using ChallengeBackend.Domain.Dtos;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ChallengeBackend.Infrastructure.Services
{
    public class KafkaService : IKafkaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<KafkaService> _logger;

        public KafkaService(IConfiguration configuration, ILogger<KafkaService> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }

        public async Task ProduceMessageAsync(KafkaMessage message)
        {
            VerifyTopic();

            try
            {
                var producerConfig  = new ProducerConfig
                {
                    BootstrapServers = _configuration["Kafka:BootstrapServers"]
                };

                var producer = new ProducerBuilder<string, string>(producerConfig).Build();

                await producer.ProduceAsync(_configuration["Kafka:Topic"], new Message<string, string>
                {
                    Key = message.Id.ToString(),
                    Value = message.NameOperation
                });
            }
            catch (ProduceException<string, string> e)
            {
                _logger.LogError($"Error trying to send a message: {e.Error.Reason}");
            }
        }

        private void VerifyTopic()
        {
            var adminConfig = new AdminClientConfig { BootstrapServers = _configuration["Kafka:BootstrapServers"] };

            using var adminClient = new AdminClientBuilder(adminConfig).Build();

            try
            {
                var topicMetadata = adminClient.GetMetadata(_configuration["Kafka:Topic"], TimeSpan.FromSeconds(10));

                if (topicMetadata.Topics.Find(t => t.Topic.Equals(_configuration["Kafka:Topic"], StringComparison.Ordinal)) == null)
                {
                    var topicSpec = new TopicSpecification
                    {
                        Name = _configuration["Kafka:Topic"],
                        NumPartitions = 1,
                        ReplicationFactor = 1
                    };

                    adminClient.CreateTopicsAsync(new[] { topicSpec }).Wait();
                }
            }
            catch (CreateTopicsException e)
            {
                _logger.LogError($"Error trying to create topic '{_configuration["Kafka:Topic"]}': {e.Results[0].Error.Reason}");
            }
        }
    }

}
