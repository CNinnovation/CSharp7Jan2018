using MyLegacyLib;
using System;

namespace NetStandardSample
{
    public class Demo
    {
        public int Add(int x, int y) => x + y;

        public string Hello(string name) => $"Hello, {name}";

        public void Hello2(string name)
        {
            var l = new Legacy();
            l.ShowMessage(name);
        }
    }
}
