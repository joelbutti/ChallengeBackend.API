using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Domain.Dtos
{
    public record struct KafkaMessage(Guid Id, string NameOperation);
}
