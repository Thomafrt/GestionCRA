using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRA.Models
{
    public enum EtatEntry
    {
        Valide,
        Refuse,
        Sauvegarde,
        Soumis
    }

    public class Entry
    {
        public int Id { get; set; }

        [Required]
        // Clé étrangère pour Employee
        public int EmployeeId { get; set; }
        // Propriété de navigation pour Employee
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        [Required]
        // Clé étrangère pour Mission
        public int MissionId { get; set; }
        // Propriété de navigation pour Mission
        [ForeignKey(nameof(MissionId))]
        public virtual Mission Mission { get; set; }

        public EtatEntry Etat { get; set; }

        [Required]
        [Range(1, 52, ErrorMessage = "Le numéro de semaine doit être compris entre 1 et 52.")]
        public int NumeroSemaine { get; set; }

        [Range(0, 12)]
        public int? HeuresLundi { get; set; }

        [Range(0, 12)]
        public int? HeuresMardi { get; set; }

        [Range(0, 12)]
        public int? HeuresMercredi { get; set; }

        [Range(0, 12)]
        public int? HeuresJeudi { get; set; }

        [Range(0, 12)]
        public int? HeuresVendredi { get; set; }

        [Range(0, 12)]
        public int? HeuresSamedi { get; set; }

        [Range(0, 12)]
        public int? HeuresDimanche { get; set; }
    }
}
