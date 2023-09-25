using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Saving_System
{
    internal interface IData<T>
    {
        void Save(T data, string path = null);

        T Load(string path = null);
    }
}
