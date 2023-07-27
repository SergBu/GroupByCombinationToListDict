using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GroupByCombinationToListDict
{

    public class TerminalTimeslotVehicle
{ 
        public TerminalTimeslotVehicle()
        {
            Version = 0;
        }

        public int Id { get; set; }
        public int? CropId { get; set; }
        public int CombinationId { get; set; }
        public int TerminalTimeslotVehicleId
        {
            get => Id;
            set => Id = value;
        }

        [JsonIgnore]
        [Comment("Идентификатор временного интервала")]
        public int TerminalTimeslotId { get; set; }

        [Comment("Идентификатор резерва временного интервала")]
        public int TerminalTimeslotReservationId { get; set; }

        public bool ShouldSerializeTerminalTimeslotReservationId() => TerminalTimeslotReservationId > 0;

        /// <summary>
        /// Версия
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        [Comment("Версия")]
        public int Version { get; set; }

        [NotMapped]
        [JsonProperty("Restrictions")]
        public IEnumerable<int> RestrictionIds
        {
            get
            {
                try
                {
                    return new List<int>();
                }
                catch
                {
                    return new List<int>();
                }
            }
        }

        [NotMapped]
        [Comment("Список идентификаторов ограничений")]
        public List<int> RestrictionsIdsInfo { get; set; } = new List<int>();

        [Comment("Дата удаления")]
        public DateTime? Deleted { get; set; }

        public override string ToString()
        {
            return $"{TerminalTimeslotId}, ({base.ToString()}), ({Version})";
        }
    }
}