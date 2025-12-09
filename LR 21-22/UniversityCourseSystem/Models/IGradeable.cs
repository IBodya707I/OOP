using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal interface IGradeable
    {
        int MaxPoints { get; set; }
        decimal CalculateGrade(decimal points);
    }
}
