using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Entities.Models
{
    [Table("Eventos")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        public string? Name { get; set; }
        
        [DataType(DataType.Date)]
        [Column(name: "Fecha")]
        public DateOnly EventDate { get; set; }
        [DataType(DataType.Time)]
        [Column(name: "Hora")]
        public TimeOnly EventTime { get; set; }
        [Column(name: "Descripcion")]
        public string? EventDescription { get; set; }
        public string Image {  get; set; }
        //public byte[] Image {  get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId {  get; set; }
        public Course Course { get; set; }


    }
}
