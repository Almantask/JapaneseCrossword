using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Helpers.Saving_Loading
{
    public interface ILoadable
    {
        void ApplyLoadData(Object obj);
        void UpdateData();
    }
}
