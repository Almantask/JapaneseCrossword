using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers.UI
{
    public static class UIHelper
    {
        #region UI helpers
        /// <summary>
        /// Clear text string value of inputed text component
        /// </summary>
        /// <param name="text"></param>
        public static void Clear(Text text)
        {
            text.text = "";
        }


        #endregion
    }
}
