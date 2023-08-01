using System;
using System.Collections.Generic;

namespace CSharp.Homework7
{
    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
