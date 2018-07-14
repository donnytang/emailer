using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Common
{
    public class EmailHelper
    {
        public static string Send(string smtpService, string sendEmail, string sendpwd)
        {
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
beilicheng27888126@gmail.com     lwt3.14159
             * 
             * 
             * 
             * string smtpService = "smtp.sina.com";
            string sendEmail = "dndtzl@sina.com";
            string sendpwd = "ww12345";*/
            smtpService = "smtp.office365.com";
            sendEmail = "beilicheng27888126@hotmail.com";
            sendpwd = "lwt3.14159";


            //确定smtp服务器地址 实例化一个Smtp客户端
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = smtpService;
            smtpclient.Port = 587;
            //smtpclient.Port = 587;
            //smtpClient.Port = "";//qq邮箱可以不用端口

            //确定发件地址与收件地址
            MailAddress sendAddress = new MailAddress(sendEmail);
            MailAddress receiveAddress = new MailAddress("1413478008@qq.com");

            //构造一个Email的Message对象 内容信息
            MailMessage mailMessage = new MailMessage(sendAddress, receiveAddress);
            mailMessage.Subject = "测试邮件" + DateTime.Now;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = $"测试邮件发送成功！！！";//<IMG src=\"data:image/png;base64,{ GetMailBody("") }\"> </IMG>";
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            mailMessage.Sender = new MailAddress(sendEmail);

            //mailMessage.Attachments.Add(new Attachment("I:\\a.txt"));
            //mailMessage.Attachments.Add(new Attachment("I:\\b.txt"));


            //邮件发送方式  通过网络发送到smtp服务器
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;

            //如果服务器支持安全连接，则将安全连接设为true
            //smtpclient.EnableSsl = true;
            try
            {
                //是否使用默认凭据，若为false，则使用自定义的证书，就是下面的networkCredential实例对象
                smtpclient.UseDefaultCredentials = false;

                //指定邮箱账号和密码,需要注意的是，这个密码是你在QQ邮箱设置里开启服务的时候给你的那个授权码
                NetworkCredential networkCredential = new NetworkCredential(sendEmail, sendpwd);
                smtpclient.Credentials = networkCredential;

                //发送邮件
                smtpclient.Send(mailMessage);
                return "发送邮件成功";

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return ex.Message;
            }
        }

        public static void SendMail(string senderId, string password, List<string> To, List<string> CC, List<string> BCC, string Subject, string Body, List<Attachment> Attachment)
        {
            SmtpClient SmtpServer = null;
            string[] ss = senderId.Split('@');

            string ServerName = ss[1];

            switch (ServerName.ToLower())
            {
                case "gmail.com":
                    SmtpServer = new SmtpClient("smtp.gmail.com");
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = true;
                    break;
                case "msn.com":
                case "live.com":
                case "outlook.com":
                    SmtpServer = new SmtpClient("smtp.live.com");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = true;
                    break;
                case "hotmail.com":
                    SmtpServer = new SmtpClient("smtp.office365.com");
                    SmtpServer.Port = 587;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = true;
                    break;

                case "aol.com":
                    SmtpServer = new SmtpClient("smtp.aol.com");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = true;
                    break;
                case "yahoo.com":
                case "ymail.com":
                case "rocketmail.com":
                case "yahoomail.com":
                    SmtpServer = new SmtpClient("smtp.mail.yahoo.com");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = false;
                    break;
                case "bk":
                case "inbox":
                case "list.ru":
                case "mail.ru":
                case "mail.ua":
                case "sina.com":
                    SmtpServer = new SmtpClient("smtp.sina.com");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = true;
                    break;
                case "qq.com":
                    SmtpServer = new SmtpClient("smtp.sina.com");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = false;
                    break;
                case "gmx.com":
                    SmtpServer = new SmtpClient("smtp.mail.yahoo.com");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    SmtpServer.EnableSsl = false;
                    break;
                case "126.com":
                    SmtpServer = new SmtpClient("smtp.126.com");
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    break;
                case "yeah.net":
                    SmtpServer = new SmtpClient("smtp.yeah.net");
                    SmtpServer.Credentials = new System.Net.NetworkCredential(senderId, password);
                    break;
                default:

                    break;


            }
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //SmtpServer.UseDefaultCredentials = false;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderId);

            foreach (string item in To)
            {
                mail.To.Add(item);
            }
            foreach (string item in CC)
            {
                mail.CC.Add(item);
            }
            foreach (string item in BCC)
            {
                mail.Bcc.Add(item);
            }

            mail.Subject = "test"; //Subject;
            mail.Body = "test body";// Body;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;

            foreach (Attachment item in Attachment)
            {
                mail.Attachments.Add(item);
            }

            try
            {
                SmtpServer.Send(mail);
            }
            catch(Exception ex)
            {
                
            }

        }

        private static string GetMailBody(string Imagefilename)
        {
            Bitmap bmp = new Bitmap("I:\\th.jpg");

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();

            String strbaser64 = Convert.ToBase64String(arr);
            return strbaser64;
        }
    }
}
