using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public interface IPage
    {
        void InsertText(string text);

        string InsertedText { get; }
    }
}
