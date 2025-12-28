using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.InputForUI.InputManagerProvider;
using GlobalEnums;
using InControl;

namespace silkmodrecord
{
    internal class mainrecordplugin : MonoBehaviour
    {
        internal StringBuilder logbuffer = new StringBuilder();
        internal string logpath;
        internal float timer;
        private void Awake()
        {
            this.enabled = true;
            logpath = Path.Combine(silkmodrecordPlugin.datapath, "log.txt");
        }
        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Y))
            {
                logbuffer.AppendLine("success");
            }
            logbuffer.AppendLine(GetHeroPos());
            timer += UnityEngine.Time.deltaTime;
            if (timer >= 1f)
            {
                File.AppendAllText(logpath, logbuffer.ToString());
                logbuffer.Clear();
                timer = 0f;
            }
        }
        public static string GetHeroPos()
        {
            if (silkmodrecordPlugin.RefKnight == null)
            {
                return string.Empty;
            }
            float HeroX = silkmodrecordPlugin.RefKnight.transform.position.x;
            float HeroY = silkmodrecordPlugin.RefKnight.transform.position.y;

            return $"{HeroX}, {HeroY}";
        }
    }
}
