﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrassTesting.Entity
{
    public class TravianPlayerId
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}
