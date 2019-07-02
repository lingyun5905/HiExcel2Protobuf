﻿/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiProtobuf
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiProtobuf.Lib
{
    class ProtoGenerate_python : ProtoGenerateBase
    {
        public ProtoGenerate_python(string name, List<VariableInfo> infos) : base(name, infos)
        {
            Path += Common.python_folder;
            if (Directory.Exists(Path))
            {
                Directory.Delete(Path, true);
            }
            Directory.CreateDirectory(Path);
            Path = Path + "/" + name + ".proto";

            var header = @"
// This is auto generated by HiProtobuf
// Support: hiramtan@live.com

// [START declaration]
syntax = ""proto3"";
package HiProtobuf;

import ""google/protobuf/timestamp.proto"";
// [END declaration]
";
            header += "message " + name + " {";
            var sw = File.AppendText(Path);
            sw.WriteLine(header);
            sw.Close();
        }
    }
}
