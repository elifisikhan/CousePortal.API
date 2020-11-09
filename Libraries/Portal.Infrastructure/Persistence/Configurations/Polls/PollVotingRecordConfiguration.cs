using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistence.Configurations.Polls
{
    public class PollVotingRecordConfiguration : IEntityTypeConfiguration<PollVotingRecord>
    {
        public void Configure(EntityTypeBuilder<PollVotingRecord> builder)
        {
            builder.Property(s => new { s.PollId, s.PollAnswerId }).IsRequired();
        }
    }
}
