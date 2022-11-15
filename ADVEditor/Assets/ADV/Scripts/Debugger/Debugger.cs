using UnityEngine;

namespace HarapekoADV
{
    public class Debugger
    {
        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="msg"></param>
        public static void Log(string msg)
        {
            Debug.Log(msg);
        }

        /// <summary>
        /// エラー出力
        /// </summary>
        /// <param name="msg"></param>
        public static void Err(string msg)
        {
            Debug.LogError(msg);
        }

    }
}