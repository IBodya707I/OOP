using System;
using Task_02.Interfaces;
namespace Task_02.Classes
{
    internal class Robot : IFakeId
    {
        string model;
        string id;
        public string Model
        {
            get { return model; }
            private set { model = value; }
        }
        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public bool IsFakeId(string code)
        {
            int x = 0;
            for (int i = id.Length - code.Length; i < id.Length; i++)
            {
                if (id[i] != code[x])
                {
                    return false;
                }
                x++;
            }
            return true;
        }
    }
}
