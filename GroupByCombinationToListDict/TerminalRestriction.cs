using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroupByCombinationToListDict
{
    public class TerminalRestriction
    {
        public TerminalRestriction()
        {
        }

        public int Id { get; set; }

        [JsonIgnore]
        [Comment("Идентификатор терминала")]
        public int TerminalId { get; set; }

        [Comment("Дата ограничения")]
        public DateTime Date { get; set; }

        [Comment("Максимальное количество т/с")]
        public int MaxVehiclesCount { get; set; }

        [Comment("Текущее количество т/с")]
        public int VehiclesCount { get; set; }

 
        public override string ToString()
        {
            return $"{TerminalId}, {Date:dd.MM.yyyy}, ({base.ToString()}) ({MaxVehiclesCount}/{VehiclesCount})";
        }
    }
}
