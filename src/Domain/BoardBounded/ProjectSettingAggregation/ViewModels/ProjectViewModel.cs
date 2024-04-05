﻿using Domainify.Domain;
using System.ComponentModel.DataAnnotations;

namespace Domain.ProjectSettingAggregation
{
    public class ProjectViewModel : ViewModel, IModifiedViewModel, IDeletableViewModel
    {
        public string Id { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        
        [Display(Name = "Modified Date")]
        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }

        public short Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<SprintViewModel> Sprints { get; set; } = new List<SprintViewModel>();
    }
}
