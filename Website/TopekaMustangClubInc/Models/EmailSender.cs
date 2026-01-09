using System.Text;
using Azure;
using Azure.Communication.Email;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TopekaMustangClubInc.Models
{
    public class EmailSender : IEmailSender
    {        
        public void SendEmail(string email, string subject, string HtmlMessage)
        {
            SendEmailAsync(email, subject, HtmlMessage).Wait();
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // This code retrieves your connection string from an environment variable.
            string connectionString = "endpoint=https://acesemail-smtp.unitedstates.communication.azure.com/;accesskey=D2JP2nlkEX9lQ8SjVmTQrDPQ8steFHe42SwfP5P0OAURIz4N6wSQJQQJ99AHACULyCppbCB9AAAAAZCSJJyH";
            var emailClient = new EmailClient(connectionString);

            EmailSendOperation emailSendOperation = emailClient.Send(
                WaitUntil.Completed,
                senderAddress: "DoNotReply@9c23caa5-9ae4-42ca-b42d-d45318094dbc.azurecomm.net",
                recipientAddress: email,                
                subject: subject,
                htmlContent: "<html>" + "<br />" +
                "<h1>Topeka Mustang Club Inc.</h1><br /><br /><p>" + htmlMessage + "</p></html>",
                plainTextContent: htmlMessage);

            return Task.CompletedTask;
        }

        public string BuildHtmlBody(string content)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title></title>    \r\n</head>\r\n<body>\r\n");
            stringBuilder.Append("<div style=\"padding: 20px; margin: 20px;\"> <!--WRAPPER-->");
            stringBuilder.Append("<div style=\"width: 90%; text-align: center; padding: 10px;\">");
            stringBuilder.Append("<!--HEADER-->\r\n    <div style=\"width: 100%;\">\r\n    <table style=\"width: 100%;\">\r\n        <tr>\r\n            <td style=\"width: 20%; text-align: left;\">\r\n                <a href=\"https://kansascash.ks.gov/\" target=\"_blank\"> \r\n                <img src=\"https://online.treasurer.state.ks.us/intranet/assets/images/treasurer-seal-bw-108x108.png\" /> </a>\r\n            </td>\r\n            <td style=\"width: 80%; color: steelblue; font-size: 1.2em; font-weight: bold; padding-bottom: 60px;\">\r\n                <p>Office of the Kansas State Treasurer<br />Steven Johnson</p>\r\n            </td>\r\n        </tr>\r\n    </table>    \r\n    </div>  \r\n    <!--HEADER-->");
            stringBuilder.Append("<!--BODY-->\r\n    <div style=\"width: 100%; text-align: left; padding-bottom: 60px;\"><br />\r\n        <p style=\"color: #888;\">");
            stringBuilder.Append(content);
            stringBuilder.Append("</p>\r\n    </div>\r\n     <!--BODY-->");
            stringBuilder.Append("<!--FOOTER-->\r\n    <div style=\"width:100%; padding-right: 20px;\">\r\n        <table style=\"width:100%;\">\r\n            <tr >\r\n                <td style=\"width:33%; text-align: left;\">\r\n                    <a href=\"tel:785-296-3171\" style=\"color: #888; text-decoration:none\">Main: (785) 296-3171</a>\r\n                </td>\r\n                <td style=\"width:33%; text-align: center;\">\r\n                    <a href=\"https://kansascash.ks.gov/contact_us.html\" target=\"_blank\" style=\"color: #888; text-decoration:none\">Contact Us</a>\r\n                </td>\r\n                <td style=\"width:33%; text-align: right;\">\r\n                    <a href=\"https://www.facebook.com/KansasTreasurer\" target=\"_blank\" style=\"color: #888; text-decoration:none\">Facebook</a>\r\n                    <a href=\"https://www.instagram.com/KansasTreasurer/\" target=\"_blank\" style=\"color: #888; text-decoration:none; display: none;\">I</a>\r\n                    <a href=\"https://twitter.com/KansasTreasurer\" target=\"_blank\" style=\"color: #888; text-decoration:none; display: none;\">T</a>\r\n                    <a href=\"https://www.youtube.com/@KansasTreasurer\" target=\"_blank\" style=\"color: #888; text-decoration:none; display: none;\">TB</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n\t</div>\r\n    <!--FOOTER-->");
            stringBuilder.Append("</div>\r\n</div> <!--WRAPPER-->\r\n</body>\r\n</html>");
            return stringBuilder.ToString();
        }
    }
}
