using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrassTesting.Entity
{
    public class TravianPlayerHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public string Nation { get; set; }

        public string Clan { get; set; }

        public int CountVillages { get; set; }

        public string RankPopulation { get; set; }

        public string CountPopulation { get; set; }

        public string RankAtt { get; set; }

        public string PointAtt { get; set; }

        public string RankDef { get; set; }

        public string PointDef { get; set; }

        public string VillagesJson { get; set; }
    }

    public class TravianPlayerHistoryConfiguration : IEntityTypeConfiguration<TravianPlayerHistory>
    {
        public void Configure(EntityTypeBuilder<TravianPlayerHistory> builder)
        {
            builder
                .HasKey(t => new { t.Id, t.Date });
        }
    }
}
