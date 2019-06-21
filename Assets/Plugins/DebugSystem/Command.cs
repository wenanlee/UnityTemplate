using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DebugSystem
{
    public class Command : MonoBehaviour
    {
        public bool IsShowUI = false;
        private string commandStr = "command:";
        void OnGUI()
        {
            if (IsShowUI)
            {
                GUI.FocusControl("MyTextField");
                GUI.SetNextControlName("MyTextField");
                commandStr = GUI.TextField(new Rect(0, 200, 800, 20), commandStr);
                Event e = Event.current;
                if (e.isKey && (e.keyCode == KeyCode.Return))
                {
                    if (commandStr != "command:" && commandStr.Length > 0)
                    {
                        RunCommand(commandStr);
                        commandStr = "";
                    }
                    GUI.FocusControl("MyTextField");
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
        private void RunCommand(string commandStr)
        {
            print(commandStr);
            string[] str = commandStr.Split(' ');
            switch (str[0])
            {
                case "showconsole":
                    GetComponent<Console>().IsShowUI = bool.Parse(str[1]);
                    break;
                case "showwarning":
                    GetComponent<Console>().IsShowWarning = bool.Parse(str[1]);
                    break;
                default:
                    break;
            }
        }
    }
}

