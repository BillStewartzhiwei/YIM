using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace StewertPlugin
{
    public class IniFile
    {
        public string Path { get; set; }

        // 构造函数
        public IniFile(string iniPath)
        {
            Path = iniPath;
        }

        // 读取INI文件
        public string Read(string section, string key, string defaultValue = "")
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, defaultValue, temp, 255, Path);
            return temp.ToString();
        }

        // 写入INI文件
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        // 删除某个Key
        public void DeleteKey(string section, string key)
        {
            Write(section, key, null);
        }

        // 删除某个Section
        public void DeleteSection(string section)
        {
            Write(section, null, null);
        }

        // 判断某个Key是否存在
        public bool KeyExists(string section, string key)
        {
            return Read(section, key).Length > 0;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }

}