using System;
using UnityEngine.UI;

namespace BetaKors.Extensions
{
    public static class ButtonExtensions
    {
        public static void ExecuteOnClick(this Button button, Action action)
        {
            button.onClick.AddListener(delegate { action(); });
        }
    }
}
