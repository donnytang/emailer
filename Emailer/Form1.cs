using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emailer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*
             1. 回复邮件修改 ok
             2. 发送多个附件 ok
             3. 将图片做为邮件主体 ok
             4. 邮箱服务器测试 126 163 yeah hotmail.com outlook.com  
             5. 使用IP代理发送邮件 ok
             
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tos = new List<string>();
            var receivers = new List<string>();
            var ccs = new List<string>();
            var bcc = new List<string>();
            var attachment = new List<Attachment>();

            tos.Add("1413478008@qq.com");

            //Common.EmailHelper.SendMail("lainhartrkqexvtz@zoho.com", "zEmAn39054", tos, ccs, bcc, "", "", attachment);
            Common.EmailHelper.SendMail("CalhounSusan1998@gmx.com", "beilicheng3.14159", tos, ccs, bcc, "", "", attachment);
            //OK Common.EmailHelper.SendMail("tangxiaowei001@gmail.com", "denise07354281", tos, ccs, bcc, "", "", attachment);
            //OK Common.EmailHelper.SendMail("beilicheng27888126@hotmail.com", "lwt3.14159", tos, ccs, bcc, "", "", attachment);
            //OK Common.EmailHelper.SendMail("donny001@yeah.net", "donny07354281", tos, ccs, bcc, "", "", attachment);


            //var msg = Common.EmailHelper.Send(txtSmtpUrl.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());

            // MessageBox.Show(msg);

            /*
na7e2m5oyx@bk.ru        j1258rknw
fsv6e2kbkqmdv@inbox.ru      hnhrod04niv
SydneyipTamsinrd@yahoo.com     Zqs277ab
cgewvssh@list.ru      vanwrIgHt421
yrb7ec3t9a@mail.ru      qf7opfjiym1
eichpgxdt@mail.ua     EndangErEd93
dndtzl@sina.com        ww12345 
lainhartrkqexvtz@zoho.com     zEmAn39054
CalhounSusan1998@gmx.com       g2AenxBH5
allisonranwtmiller@aol.com      @SUJINSHUIAOL702
linyi70355@21cn.com     fg54d1eM

#### ovsm81995hfo@126.com     ugpu2751
#### tangtan68811@yeah.net     buf8avgc
#### iyiai1@163.com     ewem3248
not ok  beilicheng27888126@gmail.com     lwt3.14159  
not ok  beilicheng27888126@gmail.com     lwt3.14159
####beilicheng27888126@hotmail.com       lwt3.14159 
            smtpService = "smtp.office365.com";
             sendEmail = "beilicheng27888126@hotmail.com";
             sendpwd = "lwt3.14159";
            smtpclient.Port = 587;

beilicheng27888126@outlook.com        beilicheng3.14159
lainhartrkqexvtz@zoho.com     zEmAn39054
CalhounSusan1998@gmx.com       g2AenxBH5
SydneyipTamsinrd@yahoo.com     Zqs277ab
beilicheng27888126@gmail.com     lwt3.14159*/

        }
    }
}
