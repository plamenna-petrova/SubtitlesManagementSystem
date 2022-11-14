﻿using SubtitlesManagementSystem.Models.Abstraction;

namespace SubtitlesManagementSystem.Models.Entities
{
    public class FilmProductionActor: BaseEntity
    {
        public string FilmProductionId { get; set; }

        public virtual FilmProduction FilmProduction { get; set; }

        public string ActorId { get; set; }

        public virtual Actor Actor { get; set; }
    }
}