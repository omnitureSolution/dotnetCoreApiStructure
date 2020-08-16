using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace LetsSuggest.Shared.Helper
{
    public class ListModel
    {
        public int? Id { get; set; }
        public String Text { get; set; }
        public String Name { get; set; }

    }
    public class ComboModel
    {
        public int? Value { get; set; }
        public String Label { get; set; }
    }
    public class EmailMessage
    {
        private List<Attachment> _attachments;
        public string SendFrom { get; set; }
        public string SenderName { get; set; }
        public List<string> SendTo { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public List<string> Cc { get; set; }
        public List<string> Bcc { get; set; }
        public bool IsBodyHtml { get; set; }
        public List<Attachment> Attachments
        {
            get { return (_attachments ?? (_attachments = new List<Attachment>())); }
            set { _attachments = value; }
        }
    }

}
