using QUp.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace QUp.Domain
{
    public class Project 
    {
        public Project()
        {
            Sprints = new List<Sprint>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Sprint> Sprints { get; set; }


    }
}
