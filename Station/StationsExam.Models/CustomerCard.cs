using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationsExam.Models
{


    public enum CardType
    {
        Normal,
        Pupil,
        Student,
        Elder,
        Debilitated
    }
  /*Name – text with max length 128 (required)
Age – integer between 0 and 120 
Card Type – values may be: "Pupil", "Student", "Elder", "Debilitated" (Injured) or "Normal" (default value: Normal)*/
   public class CustomerCard
    {
        public int Id { get; set; }
        [Required,MaxLength(128)]
        public string Name { get; set; }
        [Range(0,120)]
        public int Age { get; set; }
        public CardType CardType { get; set; }
       
    }
}
