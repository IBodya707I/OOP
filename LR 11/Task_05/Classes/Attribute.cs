using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.Classes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CustomAttribute: Attribute
    {
        private string author;
        private int revision;
        private string description;
        private string[] reviewers;
        public string Author
        {
            get { return author; }
            private set { author = value; }
        }
        public int Revision
        {
            get { return revision; }
            private set { revision = value; }
        }
        public string Description
        {
            get { return description; }
            private set { description = value; }
        }
        public string[] Reviewers
        {
            get { return reviewers; }
            private set { reviewers = value; }
        }   
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }
    }
}
