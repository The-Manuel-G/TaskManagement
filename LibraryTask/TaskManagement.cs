using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
   
        // Clase para representar los tipos de estado
        public class Status
        {

            [Key]
             [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
            public int StatusId  { get; set; } // ID único del estado
            public string Name { get; set; } = string.Empty; // Nombre del estado (ejemplo: "Pending", "Completed")

            public virtual ICollection<Status> Statuss { get; set; }

        }

        // Modelo genérico Task<T> con relación hacia Status
        public class Task<T>
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; } // ID único de la tarea
           
            public string Description { get; set; } = string.Empty; // Descripción de la tarea
            public DateTime DueDate { get; set; } // Fecha de vencimiento
            public int StatusId { get; set; } // Llave foránea hacia la tabla Status
         
            public T AdditionalData { get; set; } // Datos adicionales genéricos


        [ForeignKey("StatusId")]
            public virtual Status Status { get; set; }
    }
    }


