using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace DebugSystem
{
    public class Console : MonoBehaviour
    {
        public bool IsShowUI = false;
        public bool IsShowWarning = false;
        public string LogPath = "./log.txt";
        public string MailString;
        public List<string> messageString;
        private Vector2 scrollPosition = Vector2.zero;

        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void OnGUI()
        {
            if (IsShowUI)
            {
                string str = "";
                scrollPosition = GUI.BeginScrollView(new Rect(0, 0, 1000,200), scrollPosition, new Rect(0, 0, 1000, 20 * messageString.Count));
                for (int i = 0; i < messageString.Count; i++)
                {
                    str += messageString[i] + "\n";
                }
                GUI.Label(new Rect(0, 0, 1000, 20 * messageString.Count), str);
                GUI.EndScrollView();

                if (GUI.Button(new Rect(800, 0, 140, 40), "关"))
                {
                    IsShowUI = false;
                }
                if (GUI.Button(new Rect(800, 40, 140, 40), "打开警告"))
                {
                    IsShowWarning = !IsShowWarning;
                }
            }
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    IsShowUI = !IsShowUI;
                }
            }
        }
        private void HandleLog(string condition, string stackTrace, LogType type)
        {
            scrollPosition = new Vector2(scrollPosition.x, 100);
            switch (type)
            {
                case LogType.Error:
                    messageString.Add("<color=#ff0000> 错误 " + "   信息：" + condition + "</color>");
                    break;
                case LogType.Assert:
                    messageString.Add("<color=#ff0000> 中断 " + "   信息：" + condition + "</color>");
                    break;
                case LogType.Warning:
                    if (IsShowWarning)
                    {
                        messageString.Add("<color=#ffff00> 警告 " + "   信息：" + condition + "</color>");
                    }
                    break;
                case LogType.Log:
                    messageString.Add("<color=#ffffff> 打印 " + "   信息：" + condition + "</color>");
                    break;
                case LogType.Exception:
                    messageString.Add("<color=#ff0000> 异常 " + "   信息：" + condition + "</color>");
                    break;
                default:
                    break;
            }
        }
    }
}
